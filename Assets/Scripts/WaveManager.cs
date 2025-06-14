using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public Transform SpawnPoint;
    public List<Enemy> EnemyTypes;
    public List<Enemy> AliveEnemies = new List<Enemy>();

    public int WaveIndex = 1;
    public int NumOfEnemiesToSpawn;

    public float timeBtwnSpawns = 0.5f;
    public float TimeBtwnWaves;
    public float MaxTimeBtwnWaves = 5f;

    public bool IsInWave = false;

    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
        TimeBtwnWaves = MaxTimeBtwnWaves;
    }

    void Update()
    {
        
        if (!IsInWave)
        {
            TimeBtwnWaves -= Time.deltaTime;

            if (TimeBtwnWaves <= 0)
            {
                StartCoroutine(SpawnWave());
            }
        }

        // End wave when all enemies are dead
        if (IsInWave && AliveEnemies.Count == 0)
        {
            EndWave();
        }
    }

    IEnumerator SpawnWave()
    {
        IsInWave = true;
        NumOfEnemiesToSpawn = WaveIndex; // Set enemies based on current wave

        for (int i = 0; i < NumOfEnemiesToSpawn; i++)
        {
            int index = Random.Range(0, EnemyTypes.Count);
            Enemy enemyInstance = Instantiate(EnemyTypes[index], SpawnPoint.position, Quaternion.identity);
            AliveEnemies.Add(enemyInstance);

            yield return new WaitForSeconds(timeBtwnSpawns);
        }
    }

    void EndWave()
    {
        if (!IsInWave) return;

        IsInWave = false;
        WaveIndex++;
        TimeBtwnWaves = MaxTimeBtwnWaves;
       
    }

   
}