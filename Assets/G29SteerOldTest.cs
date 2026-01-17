using UnityEngine;

public class G29SteerOldTest : MonoBehaviour
{
    void Update()
    {
        float steer = Input.GetAxis("G29_Steer");
        Debug.Log("G29_Steer = " + steer.ToString("F3"));
    }
}
