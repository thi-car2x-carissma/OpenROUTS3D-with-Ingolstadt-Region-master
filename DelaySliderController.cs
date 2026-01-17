using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// DelaySliderController - Real-time delay adjustment for OpenROUTS3D
/// Connects UI slider to Settings.displayTimeDelay (50-150ms in 10ms steps)
/// 
/// This is a NEW script - does NOT modify any existing OpenROUTS3D code
/// Works with the existing DelayManager system
/// 
/// SETUP:
/// 1. Add this script to Assets/Scripts/
/// 2. In SimulatorScene, create UI Panel with Slider and Text
/// 3. Create empty GameObject, add this script
/// 4. Assign Slider and Text references
/// 5. Play and adjust delay while driving!
/// </summary>
public class DelaySliderController : MonoBehaviour
{
    [Header("=== UI References ===")]
    [Tooltip("Slider for adjusting delay (50-150ms)")]
    public Slider delaySlider;
    
    [Tooltip("Text showing current delay value")]
    public Text delayValueText;
    
    [Header("=== Delay Range Settings ===")]
    [Tooltip("Minimum delay in milliseconds")]
    public int minDelayMs = 50;
    
    [Tooltip("Maximum delay in milliseconds")]
    public int maxDelayMs = 150;
    
    [Tooltip("Step size in milliseconds")]
    public int stepMs = 10;
    
    // Current delay value
    private int currentDelayMs = 100;
    
    void Start()
    {
        // Read current value from Settings (convert seconds to ms)
        float currentSettingsValue = Settings.displayTimeDelay;
        currentDelayMs = Mathf.RoundToInt(currentSettingsValue * 1000f);
        
        // Clamp to valid range
        currentDelayMs = Mathf.Clamp(currentDelayMs, minDelayMs, maxDelayMs);
        
        // Snap to step
        currentDelayMs = SnapToStep(currentDelayMs);
        
        // Setup slider if assigned
        if (delaySlider != null)
        {
            delaySlider.minValue = minDelayMs;
            delaySlider.maxValue = maxDelayMs;
            delaySlider.wholeNumbers = true;
            delaySlider.value = currentDelayMs;
            
            // Remove existing listeners and add ours
            delaySlider.onValueChanged.RemoveAllListeners();
            delaySlider.onValueChanged.AddListener(OnSliderValueChanged);
        }
        else
        {
            Debug.LogWarning("[DelaySliderController] Slider not assigned!");
        }
        
        // Apply initial delay and update text
        ApplyDelayToSettings(currentDelayMs);
        UpdateDisplayText();
        
        Debug.Log("[DelaySliderController] Started with delay: " + currentDelayMs + "ms");
    }
    
    /// <summary>
    /// Called when slider value changes
    /// </summary>
    private void OnSliderValueChanged(float value)
    {
        // Snap to nearest step (10ms)
        int snappedValue = SnapToStep(Mathf.RoundToInt(value));
        
        // Only update if value actually changed
        if (snappedValue != currentDelayMs)
        {
            currentDelayMs = snappedValue;
            
            // Update slider to snapped position (without triggering callback)
            if (delaySlider != null)
            {
                delaySlider.SetValueWithoutNotify(snappedValue);
            }
            
            // Apply to Settings
            ApplyDelayToSettings(snappedValue);
            
            // Update display
            UpdateDisplayText();
        }
    }
    
    /// <summary>
    /// Snap value to nearest step (10ms increments)
    /// </summary>
    private int SnapToStep(int value)
    {
        int snapped = Mathf.RoundToInt((float)value / stepMs) * stepMs;
        return Mathf.Clamp(snapped, minDelayMs, maxDelayMs);
    }
    
    /// <summary>
    /// Apply delay to OpenROUTS3D Settings
    /// </summary>
    private void ApplyDelayToSettings(int milliseconds)
    {
        // Convert milliseconds to seconds (Settings uses seconds)
        float delayInSeconds = milliseconds / 1000f;
        
        // Set Settings.displayTimeDelay - this is what DelayManager reads
        Settings.displayTimeDelay = delayInSeconds;
        
        Debug.Log("[DelaySliderController] Set Settings.displayTimeDelay = " + delayInSeconds + "s (" + milliseconds + "ms)");
    }
    
    /// <summary>
    /// Update the UI text display
    /// </summary>
    private void UpdateDisplayText()
    {
        if (delayValueText != null)
        {
            delayValueText.text = "Delay: " + currentDelayMs + " ms";
        }
    }
    
    /// <summary>
    /// Public method to set delay from code
    /// </summary>
    public void SetDelay(int milliseconds)
    {
        int snappedValue = SnapToStep(milliseconds);
        currentDelayMs = snappedValue;
        
        if (delaySlider != null)
        {
            delaySlider.SetValueWithoutNotify(snappedValue);
        }
        
        ApplyDelayToSettings(snappedValue);
        UpdateDisplayText();
    }
    
    /// <summary>
    /// Increase delay by one step (10ms)
    /// </summary>
    public void IncreaseDelay()
    {
        SetDelay(currentDelayMs + stepMs);
    }
    
    /// <summary>
    /// Decrease delay by one step (10ms)
    /// </summary>
    public void DecreaseDelay()
    {
        SetDelay(currentDelayMs - stepMs);
    }
    
    /// <summary>
    /// Get current delay in milliseconds
    /// </summary>
    public int GetCurrentDelayMs()
    {
        return currentDelayMs;
    }
}
