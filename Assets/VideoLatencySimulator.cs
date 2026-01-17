using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// VideoLatencySimulator - Simulates network latency for teleoperated driving
/// Delays the main camera feed by 50-150ms in 10ms increments
/// For OpenROUTS3D Ingolstadt-Munich project
/// 
/// SETUP:
/// 1. Attach this script to the MAIN CAMERA (not an empty GameObject)
/// 2. Create a full-screen RawImage in your Canvas
/// 3. Create a Slider (50-150 range) and Text label
/// 4. Assign references in Inspector
/// </summary>
[RequireComponent(typeof(Camera))]
public class VideoLatencySimulator : MonoBehaviour
{
    [Header("=== Delay Settings ===")]
    [Tooltip("Current delay in milliseconds")]
    [Range(50, 150)]
    public int delayMs = 100;
    
    [Header("=== UI References ===")]
    [Tooltip("Full-screen RawImage that displays the delayed feed")]
    public RawImage delayedDisplay;
    
    [Tooltip("UI Slider for adjusting delay (optional)")]
    public Slider delaySlider;
    
    [Tooltip("UI Text showing delay value (optional)")]
    public Text delayValueText;
    
    [Header("=== Performance ===")]
    [Tooltip("Maximum frames to buffer")]
    [Range(10, 60)]
    public int maxBufferSize = 30;
    
    // Internal references
    private Camera targetCamera;
    private Queue<BufferedFrame> frameBuffer;
    private RenderTexture currentDisplayTexture;
    
    // Resolution tracking
    private int lastWidth;
    private int lastHeight;
    
    // Frame data structure
    private struct BufferedFrame
    {
        public float timestamp;
        public RenderTexture texture;
        
        public BufferedFrame(float time, RenderTexture tex)
        {
            timestamp = time;
            texture = tex;
        }
    }
    
    #region Unity Lifecycle
    
    void Awake()
    {
        // Get camera component on this GameObject
        targetCamera = GetComponent<Camera>();
        
        if (targetCamera == null)
        {
            Debug.LogError("[VideoLatencySimulator] This script must be attached to a Camera!");
            enabled = false;
            return;
        }
        
        // Initialize frame buffer
        frameBuffer = new Queue<BufferedFrame>();
        
        // Store initial resolution
        lastWidth = Screen.width;
        lastHeight = Screen.height;
    }
    
    void Start()
    {
        // Validate UI references
        if (delayedDisplay == null)
        {
            Debug.LogError("[VideoLatencySimulator] Delayed Display (RawImage) is not assigned!");
            enabled = false;
            return;
        }
        
        // Disable raycast on RawImage so it doesn't block UI interactions
        delayedDisplay.raycastTarget = false;
        
        // Setup slider
        SetupSlider();
        
        // Update UI text
        UpdateDelayText();
        
        Debug.Log("[VideoLatencySimulator] Initialized with " + delayMs + "ms delay");
    }
    
    void OnDestroy()
    {
        CleanupAllTextures();
    }
    
    void OnDisable()
    {
        CleanupAllTextures();
    }
    
    #endregion
    
    #region Frame Capture and Display
    
    /// <summary>
    /// Called after camera finishes rendering - captures the frame
    /// </summary>
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // Check for resolution changes
        HandleResolutionChange();
        
        // Create new render texture for this frame
        RenderTexture frameTexture = CreateRenderTexture();
        
        // Copy current frame to our buffer texture
        Graphics.Blit(source, frameTexture);
        
        // Add to buffer with timestamp
        frameBuffer.Enqueue(new BufferedFrame(Time.unscaledTime, frameTexture));
        
        // Prevent buffer overflow
        while (frameBuffer.Count > maxBufferSize)
        {
            BufferedFrame oldFrame = frameBuffer.Dequeue();
            ReleaseRenderTexture(oldFrame.texture);
        }
        
        // Find and display the appropriately delayed frame
        DisplayDelayedFrame();
        
        // Still output to screen (required by OnRenderImage)
        Graphics.Blit(source, destination);
    }
    
    private void DisplayDelayedFrame()
    {
        if (delayedDisplay == null || frameBuffer.Count == 0) return;
        
        float delaySeconds = delayMs / 1000f;
        float targetTime = Time.unscaledTime - delaySeconds;
        
        BufferedFrame? frameToDisplay = null;
        
        // Find the most recent frame that should be displayed (timestamp <= targetTime)
        while (frameBuffer.Count > 1)
        {
            BufferedFrame oldestFrame = frameBuffer.Peek();
            
            if (oldestFrame.timestamp <= targetTime)
            {
                // This frame is old enough to display
                BufferedFrame frame = frameBuffer.Dequeue();
                
                // Release previous frame if we had one queued
                if (frameToDisplay.HasValue)
                {
                    ReleaseRenderTexture(frameToDisplay.Value.texture);
                }
                
                frameToDisplay = frame;
            }
            else
            {
                // This frame is too new, stop looking
                break;
            }
        }
        
        // Display the delayed frame
        if (frameToDisplay.HasValue)
        {
            // Release old display texture
            if (currentDisplayTexture != null && currentDisplayTexture != frameToDisplay.Value.texture)
            {
                ReleaseRenderTexture(currentDisplayTexture);
            }
            
            currentDisplayTexture = frameToDisplay.Value.texture;
            delayedDisplay.texture = currentDisplayTexture;
        }
    }
    
    #endregion
    
    #region Texture Management
    
    private RenderTexture CreateRenderTexture()
    {
        RenderTexture rt = new RenderTexture(lastWidth, lastHeight, 0, RenderTextureFormat.ARGB32);
        rt.antiAliasing = 1;
        rt.filterMode = FilterMode.Bilinear;
        rt.Create();
        return rt;
    }
    
    private void ReleaseRenderTexture(RenderTexture rt)
    {
        if (rt != null)
        {
            rt.Release();
            Destroy(rt);
        }
    }
    
    private void HandleResolutionChange()
    {
        if (Screen.width != lastWidth || Screen.height != lastHeight)
        {
            Debug.Log("[VideoLatencySimulator] Resolution changed, clearing buffer");
            
            // Clear all buffered frames
            CleanupAllTextures();
            
            // Reinitialize buffer
            frameBuffer = new Queue<BufferedFrame>();
            
            // Update stored resolution
            lastWidth = Screen.width;
            lastHeight = Screen.height;
        }
    }
    
    private void CleanupAllTextures()
    {
        if (frameBuffer != null)
        {
            while (frameBuffer.Count > 0)
            {
                BufferedFrame frame = frameBuffer.Dequeue();
                ReleaseRenderTexture(frame.texture);
            }
        }
        
        if (currentDisplayTexture != null)
        {
            ReleaseRenderTexture(currentDisplayTexture);
            currentDisplayTexture = null;
        }
    }
    
    #endregion
    
    #region UI Controls
    
    private void SetupSlider()
    {
        if (delaySlider == null) return;
        
        delaySlider.minValue = 50;
        delaySlider.maxValue = 150;
        delaySlider.wholeNumbers = true;
        delaySlider.value = delayMs;
        
        // Remove any existing listeners to prevent duplicates
        delaySlider.onValueChanged.RemoveAllListeners();
        delaySlider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    
    /// <summary>
    /// Called when slider value changes
    /// </summary>
    public void OnSliderValueChanged(float value)
    {
        // Snap to nearest 10ms
        int snappedValue = Mathf.RoundToInt(value / 10f) * 10;
        snappedValue = Mathf.Clamp(snappedValue, 50, 150);
        
        // Update delay
        delayMs = snappedValue;
        
        // Snap slider position
        if (delaySlider != null && Mathf.Abs(delaySlider.value - snappedValue) > 0.1f)
        {
            delaySlider.SetValueWithoutNotify(snappedValue);
        }
        
        // Update text
        UpdateDelayText();
    }
    
    private void UpdateDelayText()
    {
        if (delayValueText != null)
        {
            delayValueText.text = "Delay: " + delayMs + " ms";
        }
    }
    
    /// <summary>
    /// Public method to set delay via code
    /// </summary>
    public void SetDelay(int milliseconds)
    {
        // Snap to 10ms increments
        int snappedValue = Mathf.RoundToInt(milliseconds / 10f) * 10;
        delayMs = Mathf.Clamp(snappedValue, 50, 150);
        
        // Update slider
        if (delaySlider != null)
        {
            delaySlider.SetValueWithoutNotify(delayMs);
        }
        
        // Update text
        UpdateDelayText();
    }
    
    /// <summary>
    /// Increase delay by 10ms
    /// </summary>
    public void IncreaseDelay()
    {
        SetDelay(delayMs + 10);
    }
    
    /// <summary>
    /// Decrease delay by 10ms
    /// </summary>
    public void DecreaseDelay()
    {
        SetDelay(delayMs - 10);
    }
    
    #endregion
}
