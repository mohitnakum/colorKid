using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public Button playButton;
    public Button galleryButton;
    public Button settingsButton;

    public ColorKidInput inputActions;

    private void Awake()
    {
        inputActions = new ColorKidInput();
    }

    private void OnEnable()
    {
        inputActions.UI.Enable();
        inputActions.UI.Click.performed += OnClick;
    }

    private void OnDisable()
    {
        inputActions.UI.Click.performed -= OnClick;
        inputActions.UI.Disable();
    }

    private void Start()
    {
        playButton.onClick.AddListener(OnPlay);
        galleryButton.onClick.AddListener(OnGallery);
        settingsButton.onClick.AddListener(OnSettings);
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("GalleryScene");
    }

    public void OnGallery()
    {
        SceneManager.LoadScene("GalleryScene");
    }

    public void OnSettings()
    {
        Debug.Log("Settings button clicked");
    }

    private void OnClick(InputAction.CallbackContext context)
    {
        Debug.Log("UI Click detected via Input System");
    }
}
