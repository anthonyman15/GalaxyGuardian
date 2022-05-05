using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    private int currentEnemy = 0;
    public int waveBeforeNextType = 7;
    private Transform WorldSize;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public int wave = 1;

    private int waveSize = 0;
    public int waveSizeInc = 2;
    public int waveSizeLimit = 50;
    private int remainingSpawns = 0;

    void Start()
    {
        WorldSize = GameObject.Find("Tilemap_Base").GetComponent<Tilemap>().transform;
    }

    void Update()
    {
        if(remainingSpawns > 0)
        {
            if (timeBtwSpawns <= 0)
                DoSpawn();
            else
                timeBtwSpawns -= Time.deltaTime;
        }
        else
        {
            if (GameObject.FindObjectOfType<Enemy>() == null){
                NextWave();
            }
        }
            //Check wave finish
            //Increament size and the wave
            //Wait until the player pass the previous wave
    }

    private Vector3 RandomPos() =>
        new Vector3(Random.Range(0, WorldSize.right.x), Random.Range(0, WorldSize.up.y), 0);

    private void DoSpawn()
    {
        timeBtwSpawns = startTimeBtwSpawns;
        remainingSpawns--;
        Instantiate(enemies[currentEnemy], RandomPos(), Quaternion.identity);
        
    }

    private void NextWave()
    {
        waveSize += waveSizeInc;
        waveSize = Mathf.Min(waveSize, waveSizeLimit);
        
        wave++;
        WaveCounter.waveCounter += 1;
        GameOverWave.waveCounter += 1;
        if (wave > 0 && wave% waveBeforeNextType == 0)
        {
            currentEnemy++;
            waveSize = waveSizeInc;
        }
        remainingSpawns = waveSize;

    }

}