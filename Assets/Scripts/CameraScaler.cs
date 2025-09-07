using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScaler : MonoBehaviour
{
    [Header("Reference Resolution (Width:Height)")]
    public float targetWidth = 1080f;
    public float targetHeight = 1920f;

    private Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        UpdateCamera();
    }

    void UpdateCamera()
    {
        // Aspect ratios
        float targetAspect = targetWidth / targetHeight;
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Compare device aspect to reference
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            // Wider screen → increase orthographic size
            cam.orthographicSize = cam.orthographicSize / scaleHeight;
        }
        // else → keep default size (reference aspect)
    }
}
