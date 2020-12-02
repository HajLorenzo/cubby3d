using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private static Spawner _instance;
    public static Spawner Instance => _instance;

    [SerializeField] private Transform[] spawnPos;

    private void Awake()
    {
        _instance = this;
    }
    public void SpawnEnemy()
    {
        GameObject enemy = ObjectPool.Instance.GetEnemy();
        enemy.transform.position = spawnPos[Random.Range(0, 2)].position;
        enemy.SetActive(true);
    }
}
