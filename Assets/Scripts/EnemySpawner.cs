using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance{get; private set;}
    public List<EnemyWave> waveList;
    public Coroutine spawnCoroutine;
    public Transform startPoint;
    private int enemyCount = 0;


    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        foreach(EnemyWave wave in waveList)
        {
            for(int i = 0; i < wave.count; ++i)
            {
                GameObject.Instantiate(wave.enemyPrefab, startPoint.position, Quaternion.identity);
                ++ enemyCount;
                yield return new WaitForSeconds(wave.rate);
            }
            while(enemyCount > 0){
                yield return 0;
            }
        }
        GameManager.Instance.Success();
        yield return null;
    }

    public void StopSpawn()
    {
        StopCoroutine(spawnCoroutine);
    }

    public void DecreaseEnemyCount()
    {
        if(enemyCount > 0)
        {
            --enemyCount;
        }
    }
}
