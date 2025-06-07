using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public Transform SpawnPoint;
    public int NumOfEnemiesToSpawn;
    public int WaveIndex = 1;
    public List<Enemy> EnemyTypes;
    public List<Enemy> EnemiesToSpawn;
    public List<Enemy> AliveEnemies;
    public float timeBtwnSpawns;
    public float MaxtimeBtwnSpawns;
    public bool IsInWave;
    public float TimeBtwnWaves;
    public float MaxTimeBtwnWaves;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        TimeBtwnWaves -= Time.deltaTime;
        if(TimeBtwnWaves <= 0 && !IsInWave)
        {
            
            NumOfEnemiesToSpawn = NumOfEnemiesToSpawn + WaveIndex;
            SpawnWave();
        }

    }


    void SpawnWave()
    {
        
        IsInWave = true;
       
        for(int i = 0; i < NumOfEnemiesToSpawn; i++) 
        {
            
                int EnemyIndex = Random.Range(0, EnemyTypes.Count);
                Enemy enemy = EnemyTypes[EnemyIndex];
                EnemiesToSpawn.Add(enemy);
        }

        for(int i = EnemiesToSpawn.Count; i > 0; i--)
        {
            while(timeBtwnSpawns > 0)
            {
                timeBtwnSpawns -= Time.deltaTime;
            }
            
            if(timeBtwnSpawns <= 0)
            {
               AliveEnemies.Add(EnemiesToSpawn[0]);
               Instantiate(AliveEnemies[0], SpawnPoint.position, Quaternion.identity);
                EnemiesToSpawn.Remove(EnemiesToSpawn[0]);
                timeBtwnSpawns = MaxtimeBtwnSpawns;
            }
        }
        
        while(AliveEnemies.Count > 0)
        {
            IsInWave = true;
        }

        WaveIndex++;
        TimeBtwnWaves = MaxTimeBtwnWaves;
        IsInWave = false;
    }
}
