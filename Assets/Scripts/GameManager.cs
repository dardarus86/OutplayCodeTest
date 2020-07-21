using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Enemy EnemyPrefab;
    [SerializeField] Player PlayerPrefab;
    [SerializeField] GameObject enemiesSpawner;
    [SerializeField] int numberOfEnemiesToSpawn = 5;

    
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 playerSpawnPosition = new Vector3(0, 0, 0);
       // Instantiate(PlayerPrefab, playerSpawnPosition, Quaternion.identity);
        SpawnSetNumOfEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5.75f, 5.75f), Random.Range(-3.31f, 3.31f), 0);
        Enemy enemy = Instantiate(EnemyPrefab,spawnPosition,Quaternion.identity)as Enemy;
        enemy.transform.parent = transform;
    }

    public void SpawnSetNumOfEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            SpawnEnemy();
        }
    }
}
