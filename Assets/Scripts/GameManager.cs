using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public int unlockedImages = 1;
    [HideInInspector] public int currentImageId;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadProgress();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadImage(int imageId)
    {
        currentImageId = imageId;
        SceneManager.LoadScene("ColoringScene");
    }

    public void CompleteImage()
    {
        if (currentImageId >= unlockedImages)
        {
            unlockedImages = currentImageId + 1;
            SaveProgress();
        }
    }

    public void GoToReward()
    {
        SceneManager.LoadScene("RewardScene");
    }

    public void LoadProgress()
    {
        unlockedImages = PlayerPrefs.GetInt("UnlockedImages", 1);
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("UnlockedImages", unlockedImages);
        PlayerPrefs.Save();
    }
}
