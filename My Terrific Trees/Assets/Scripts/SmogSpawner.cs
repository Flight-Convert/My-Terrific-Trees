using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogSpawner : MonoBehaviour
{
    public GameObject[] cloudVariants;

    public float minSpeed = 0.25f;
    public float maxSpeed = 0.5f;
    public float verticalSpawnRange = 3;
    public float horizontalSpawnPos = -5;
    public float minDelay = 2f;
    public float dir = 1;


    void Start()
    {
        StartCoroutine(spawnClouds());
    }

    void SpawnCloud()
    {
        int index = Random.Range(0, cloudVariants.Length);
        Vector3 spawnPos = new Vector3(horizontalSpawnPos, 1, Random.Range(-verticalSpawnRange, verticalSpawnRange));
        SmogMovement spawnedSmog = Instantiate(cloudVariants[index], spawnPos, cloudVariants[index].transform.rotation).GetComponent<SmogMovement>();
        spawnedSmog.speed = new Vector2(Random.Range(0.5f, 1) * dir, 0).normalized * Random.Range(minSpeed, maxSpeed);
    }

    IEnumerator spawnClouds()
    {
        while (!GameManager.instance.ended)
        {
            SpawnCloud();
            
            float delay = GameManager.instance.score / GameManager.instance.targetScore;
            delay = delay * 3f;

            yield return new WaitForSeconds(minDelay + delay);
        }

        if (!GameManager.instance.won)
        {
            while(true)
            {
                SpawnCloud();

                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
