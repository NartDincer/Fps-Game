using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinSpawner : MonoBehaviour
{
    Vector3 coinSpawnPosition;
    private float timer;
    private float reCreateTime = 30f;
   

    public GameObject coinPrefab;
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
        coinSpawnPosition = new Vector3(Random.Range(245f, 347f), 23.4f, Random.Range(223f, 312f));
        Instantiate(coinPrefab, coinSpawnPosition, Quaternion.identity);
    }
}
