using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner: MonoBehaviour
{
    Vector3 enemySpawnPosition;
    private float timer;
    private float reCreateTime = 7f;

    public GameObject enemyPrefab;
    void Start()
    {
        timer = reCreateTime;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            CreateCoin();
            timer = reCreateTime;
        }
    }

    public void CreateCoin()
    {
        enemySpawnPosition = new Vector3(Random.Range(245f, 347f), 23.4f, Random.Range(223f, 312f));
        Instantiate(enemyPrefab, enemySpawnPosition, Quaternion.identity);
    }
}
