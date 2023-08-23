using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    public Transform[] spawnPoints;
    Ship ship;

    public float timeBetweenSpawns;
    private float nextSpawnTime;
    private void Start()
    {
        ship = FindObjectOfType<Ship>();
    }

    private void Update()
    {
        if (ship != null)
        {
            if (Time.time > nextSpawnTime)
            {
                Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                nextSpawnTime = Time.time + timeBetweenSpawns;
            }
        }
    }
}
