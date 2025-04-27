using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;

    [SerializeField] private GameObject[] eats;
    [SerializeField] private GameObject[] passes;
    [SerializeField] private List<Transform> spawnPoints;

    [SerializeField] private float startDelayTime = 1.5f;
    [SerializeField] private float delayTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        spawnPoints = new List<Transform>(spawnPoints);
        delayTime = startDelayTime;

        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(delayTime);

        while (true)
        {
            //check for score

            SpawnThings();
            yield return new WaitForSeconds(delayTime);
        }
    }

    public void SpawnThings()
    {
        var spawnIndex = Random.Range(0, spawnPoints.Count);
        var spawnPoint = spawnPoints[spawnIndex].position;

        bool spawnEats = Random.Range(0, 2) == 0;

        if (spawnEats)
        {
            var itemIndex = Random.Range(0, eats.Length);
            Instantiate(eats[itemIndex], spawnPoint, Quaternion.identity);
        }
        else
        {
            var itemIndex = Random.Range(0, passes.Length);
            Instantiate(passes[itemIndex], spawnPoint, Quaternion.identity);
        }
    }

    public void UpdateDelay(float delayBuff)
    {
        delayTime -= delayBuff;

        if (delayTime >= 0.1)
        { delayTime -= delayBuff; }
    }
}
