using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{

    public GameObject enemy;
    public List<GameObject> enemies = new List<GameObject>();
    public Transform[] spawnSpots;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public int wave = 0;

    void Update()
    {
        if (wave == 0)
        {
            if (timeBtwSpawns <= 0)
            {
                int randPos = Random.Range(0, spawnSpots.Length);
                Instantiate(enemy, spawnSpots[randPos].position, Quaternion.identity);
                enemies.Add(enemy);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
            if (enemies.Count == 5)
            {
                wave += 1;
                enemies.Clear();
            }
        }
    }
}