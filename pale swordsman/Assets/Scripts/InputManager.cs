using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    public delegate void StartTouchEvent();
    public event StartTouchEvent OnStartTouch;

    public delegate void EndTouchEvent();
    public event EndTouchEvent OnEndTouch;

    private TouchControlls touchControlls;

    private void Awake()
    {
        instance = this;

        touchControlls = new TouchControlls();
    }

    private void OnEnable()
    {
        touchControlls.Enable();
    }

    private void OnDisable()
    {
        touchControlls.Disable();
    }


    private void Start()
    {
        touchControlls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchControlls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null) 
        {
            OnStartTouch();
        }
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null) 
        {
            OnEndTouch();
        }
    }
}
