using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider bufferSlider;

    private float lerpSpeed = 0.05f;

    public static HealthBar instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        healthSlider.value = PlayerController.instance.health;
    }

    private void Update()
    {
        if (healthSlider.value != PlayerController.instance.health)
        {
            healthSlider.value = PlayerController.instance.health;
        }

        if (healthSlider.value != bufferSlider.value)
        {
            bufferSlider.value = Mathf.Lerp(bufferSlider.value, PlayerController.instance.health, lerpSpeed);
        }
    }
}
