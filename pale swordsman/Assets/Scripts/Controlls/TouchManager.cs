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
            ZoneController.instance.ZoneOn();
        }

        else if (touchPressAction.WasReleasedThisFrame())
        {
            ZoneController.instance.ZoneOff();
        }
    }
}
