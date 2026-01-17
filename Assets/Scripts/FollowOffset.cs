using UnityEngine;
public class FollowOffset : MonoBehaviour
{
    public Transform carRoot;
    public Vector3 localPos = new Vector3(0f, 1.25f, 0.25f);
    public Vector3 localEuler = new Vector3(0f, 180f, 0f);
    public float fov = 35f;
    void LateUpdate()
    {
        if (!carRoot) return;
        transform.position = carRoot.TransformPoint(localPos);
        transform.rotation = carRoot.rotation * Quaternion.Euler(localEuler);
        var cam = GetComponent<Camera>();
        if (cam) cam.fieldOfView = fov;
    }
}
