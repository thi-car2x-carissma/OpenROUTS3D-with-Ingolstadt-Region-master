using UnityEngine;

public class ActivateDisplays : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Debug.Log("ActivateDisplays START. Displays detected = " + Display.displays.Length);

        if (Display.displays.Length > 1)
            Display.displays[1].Activate(Display.displays[1].systemWidth, Display.displays[1].systemHeight, 60);

        if (Display.displays.Length > 2)
            Display.displays[2].Activate(Display.displays[2].systemWidth, Display.displays[2].systemHeight, 60);
    }
}
