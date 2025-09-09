using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ImageData
{
    public int id;
    public string name;
    public string category;
    public string imagePath;
}

[System.Serializable]
public class ImageDataList
{
    public List<ImageData> images;
}

public class DataLoader : MonoBehaviour
{
    public static DataLoader instance;

    public List<ImageData> allImages;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadData()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("images");
        if (jsonFile != null)
        {
            ImageDataList dataList = JsonUtility.FromJson<ImageDataList>(jsonFile.text);
            allImages = dataList.images;
        }
        else
        {
            Debug.LogError("JSON file not found in Resources folder.");
        }
    }

    public ImageData GetImageById(int id)
    {
        return allImages.Find(image => image.id == id);
    }
}
