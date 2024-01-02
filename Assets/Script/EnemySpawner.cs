using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float TimeCounter = 0;
    private float elapsedTimeSinceSpawn = 0;
    private float SpawnQuota = 0;

    private PlayerController Player;

    [SerializeField] ObjectPool EnemyPool;

    [SerializeField] float SpawnRatePerTier = 0.1f;
    [SerializeField] float DangerINcrement = 10; //how many seconds does it take to increase the spawn rate;
    [SerializeField] float SpawnDistance = 8;

    private void Start()
    {
        Player = GameManager.instance.controller;
    }

    private void Update()
    {
        TimeCounter += Time.deltaTime;
        elapsedTimeSinceSpawn += Time.deltaTime;
        SpawnQuota = 1/(((TimeCounter / DangerINcrement)+1) * SpawnRatePerTier);

        while (elapsedTimeSinceSpawn > SpawnQuota)
        {
            //Debug.Log("Trying to Spawn" + ((Mathf.Sqrt(TimeCounter) / DangerINcrement) * SpawnRatePerTier) + "Enemies Per Second");
            SpawnEnemy();
            elapsedTimeSinceSpawn -= SpawnQuota;
        }
    }

    private void SpawnEnemy()
    {
        GameObject Enemy = EnemyPool.GetPooledObject();
        if (Enemy != null)
        {
            
            Enemy.transform.position = Player.transform.position + new Vector3((Random.value)*2-1, (Random.value)*2-1,0).normalized*SpawnDistance;
            
            Enemy.SetActive(true);
        }
    }

}
