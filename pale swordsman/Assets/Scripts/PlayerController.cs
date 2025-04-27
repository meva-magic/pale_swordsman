using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [SerializeField] private float maxHealth = 90f;
    public float health;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }

        private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Eat"))
        {
            TakeDamage(30);
            Destroy(other.gameObject);
        }   

        else if (other.CompareTag("Pass"))
        {
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            //game over
        }

        //HealthBar.instance.UpdateHealthBar();
    }
}
