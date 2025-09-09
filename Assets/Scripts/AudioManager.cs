using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource bgMusicSource;
    public AudioSource sfxSource;

    public AudioClip buttonClick;
    public AudioClip colorFill;
    public AudioClip reward;

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

    public void PlayBackgroundMusic()
    {
        if (!bgMusicSource.isPlaying)
        {
            bgMusicSource.Play();
        }
    }

    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClick);
    }

    public void PlayColorFill()
    {
        sfxSource.PlayOneShot(colorFill);
    }

    public void PlayReward()
    {
        sfxSource.PlayOneShot(reward);
    }
}
