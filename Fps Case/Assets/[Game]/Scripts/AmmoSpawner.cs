using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    private float timer;
    private float reCreateTime = 30f;

    public GameObject ammoPrefab;

    Vector3 ammoSpawnPosition;
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
            CreateAmmo();
            timer = reCreateTime;
        }
    }
    public void CreateAmmo()
    {
        ammoSpawnPosition = new Vector3(Random.Range(245f, 347f), 23.4f, Random.Range(223f, 312f));
        Instantiate(ammoPrefab, ammoSpawnPosition, Quaternion.identity);
    }
}
