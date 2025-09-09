using UnityEngine;
using UnityEngine.InputSystem;

public class ColorFill : MonoBehaviour
{
    public Color selectedColor = Color.red;
    public ColorKidInput inputActions;

    private void Awake()
    {
        inputActions = new ColorKidInput();
    }

    private void OnEnable()
    {
        inputActions.Gameplay.Enable();
    }

    private void OnDisable()
    {
        inputActions.Gameplay.Disable();
    }

    private void Update()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touchPos), Vector2.zero);
            if (hit.collider != null)
            {
                FillColor(hit.collider.gameObject);
            }
        }
    }

    public void FillColor(GameObject area)
    {
        SpriteRenderer sr = area.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = selectedColor;
        }
    }
}
