using UnityEngine;

public class FlashlightFollowCamera : MonoBehaviour
{
    public Transform cameraTransform;

    void LateUpdate()
    {
        transform.rotation = cameraTransform.rotation;
    }
}
