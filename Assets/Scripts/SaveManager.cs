using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveImage(Texture2D image, string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName + ".png");
        byte[] bytes = image.EncodeToPNG();
        File.WriteAllBytes(path, bytes);
        Debug.Log("Image saved at " + path);
    }

    public Texture2D LoadImage(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName + ".png");
        if (File.Exists(path))
        {
            byte[] bytes = File.ReadAllBytes(path);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(bytes);
            return tex;
        }
        Debug.Log("Image not found at " + path);
        return null;
    }
}
