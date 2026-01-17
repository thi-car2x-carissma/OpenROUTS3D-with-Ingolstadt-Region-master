using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class AnyDeviceSteerFinder : MonoBehaviour
{
    public float changeThreshold = 0.01f;

    InputDevice[] devices;
    AxisControl[][] axes;
    float[][] last;

    void Start()
    {
        devices = InputSystem.devices.ToArray();
        axes = devices.Select(d => d.allControls.OfType<AxisControl>().ToArray()).ToArray();
        last = axes.Select(a => a.Select(x => x.ReadValue()).ToArray()).ToArray();

        Debug.Log("AnyDeviceSteerFinder ready. CLEAR Console, click Game view, then turn ONLY the wheel.");
        Debug.Log("Look for: STEER_DEVICE:");
    }

    void Update()
    {
        float bestDelta = 0f;
        string bestMsg = null;

        for (int di = 0; di < devices.Length; di++)
        {
            for (int ai = 0; ai < axes[di].Length; ai++)
            {
                float v = axes[di][ai].ReadValue();
                float d = Mathf.Abs(v - last[di][ai]);
                last[di][ai] = v;

                if (d > bestDelta)
                {
                    bestDelta = d;
                    bestMsg = $"STEER_DEVICE: {devices[di].displayName} | {axes[di][ai].path} | value={v:F3} | delta={d:F3}";
                }
            }
        }

        if (bestMsg != null && bestDelta > changeThreshold)
            Debug.Log(bestMsg);
    }
}
