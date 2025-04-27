using UnityEngine;

public class ZoneController : MonoBehaviour
{
    public static ZoneController instance;

    [SerializeField] GameObject zone;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ZoneOff();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Eat"))
        {
            ScoreManager.instance.UpdateScore(50);
            Destroy(other.gameObject);
        }   

        else if (other.CompareTag("Pass"))
        {
            PlayerController.instance.TakeDamage(30);
            Destroy(other.gameObject);
        }
    }

    public void ZoneOn()
    {
        zone.SetActive(true);
    }

    public void ZoneOff()
    {
        zone.SetActive(false);
    }
}
