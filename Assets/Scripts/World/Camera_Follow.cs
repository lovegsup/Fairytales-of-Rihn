using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target;

    private void FixedUpdate()
    {
        transform.position = target.position + new Vector3(0, 0.8f, -10f);
    }
}