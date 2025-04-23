using UnityEngine;

public class ZoneController : MonoBehaviour
{
    private InputManager inputManager;

    [SerializeField] GameObject zone; // The zone GameObject to be activated/deactivated
    private bool isZoneActive; // Track the active state of the zone

    public static ZoneController instance;

    private void Awake()
    {
        instance = this;
        inputManager = InputManager.instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += ActivateZone;   // Subscribe to touch start
        inputManager.OnEndTouch += DeactivateZone;   // Subscribe to touch end
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= ActivateZone;   // Unsubscribe on disable
        inputManager.OnEndTouch -= DeactivateZone;   // Unsubscribe on disable
    }

    private void ActivateZone()
    {
        if (!isZoneActive) // Check if the zone is not already active
        {
            zone.SetActive(true); // Activate the zone
            isZoneActive = true;   // Update the state
        }
    }

    private void DeactivateZone()
    {
        if (isZoneActive) // Check if the zone is currently active
        {
            zone.SetActive(false); // Deactivate the zone
            isZoneActive = false;   // Update the state
        }
    }
}
