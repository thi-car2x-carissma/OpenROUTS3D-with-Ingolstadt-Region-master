using UnityEngine;

public class DayNightToggle : MonoBehaviour
{
    [Header("Main light (sun)")]
    public Light sunLight;

    [Header("Skyboxes (optional)")]
    public Material daySkybox;
    public Material nightSkybox;

    [Header("Ambient light")]
    public Color dayAmbient = Color.white;
    public Color nightAmbient = Color.black;

    [Header("Day / Night settings")]
    public float dayIntensity = 1.1f;
    public float nightIntensity = 0.1f;
    public bool isDay = true;

    void Start()
    {
        ApplyState();
    }

    void Update()
    {
        // Simple: toggle with N key using the old Input API
        if (Input.GetKeyDown(KeyCode.N))
        {
            isDay = !isDay;
            ApplyState();
        }
    }

    void ApplyState()
    {
        if (sunLight != null)
        {
            sunLight.intensity = isDay ? dayIntensity : nightIntensity;
        }

        if (isDay && daySkybox != null)
        {
            RenderSettings.skybox = daySkybox;
        }
        else if (!isDay && nightSkybox != null)
        {
            RenderSettings.skybox = nightSkybox;
        }

        RenderSettings.ambientLight = isDay ? dayAmbient : nightAmbient;
        DynamicGI.UpdateEnvironment();
    }
}
