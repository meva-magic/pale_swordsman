using UnityEngine;

public class MoveThing : MonoBehaviour
{
    public static MoveThing instance;

    [SerializeField] private  float speed;

    private Transform target;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target.position, ScoreManager.instance.globalSpeed * Time.deltaTime);
    }

    public void UpdateSpeed(float speedBuff)
    {
        speed += speedBuff;
    }
}
