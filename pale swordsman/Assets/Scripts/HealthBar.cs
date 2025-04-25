using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider bufferSlider;

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float health;

    private float lerpSpeed = 0.05f;

    public static HealthBar instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (healthSlider.value != bufferSlider.value)
        {
            bufferSlider.value = Mathf.Lerp(bufferSlider.value, health, lerpSpeed);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            //game over
        }
    }
}
