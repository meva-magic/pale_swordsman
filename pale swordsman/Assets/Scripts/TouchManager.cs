using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    private PlayerInput playerInput;

    private InputAction touchPressAction;

    public int count;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        touchPressAction = playerInput.actions["TouchPress"];
    }

    private void Update()
    {
        if (touchPressAction.WasPressedThisFrame())
        {
        }

        else if (touchPressAction.WasReleasedThisFrame())
        {
        }
    }
}
