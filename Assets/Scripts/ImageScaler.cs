using UnityEngine;

public class ImageScaler : MonoBehaviour
{
    public RectTransform imageRect;
    public float padding = 50f;

    void Start()
    {
        ScaleImage();
    }

    void ScaleImage()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        float size = Mathf.Min(screenWidth, screenHeight) - padding;
        imageRect.sizeDelta = new Vector2(size, size);
    }
}
