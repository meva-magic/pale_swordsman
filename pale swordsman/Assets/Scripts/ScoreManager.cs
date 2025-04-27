using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public float score;

    [SerializeField] private  float speedBuff = 0.3f;
    [SerializeField] private float delayBuff = 0.1f;
    public float globalSpeed = 2;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        score = 0;
    }

    public void UpdateScore(int points)
    {
        score += points;

        //MoveThing.instance.UpdateSpeed(speedBuff);
        
        if (globalSpeed <= 6)
        { globalSpeed += speedBuff; }

        Spawner.instance.UpdateDelay(delayBuff);
    }
}
