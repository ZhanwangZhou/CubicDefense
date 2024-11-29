using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance{get; private set;}
    public List<EnemyWave> waveList;
    public Transform startPoint;
    private int enemyCount = 0;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        yield return null;
    }

    public void DecreaseEnemyCount()
    {
        if(enemyCount > 0)
        {
            --enemyCount;
        }
    }
}
