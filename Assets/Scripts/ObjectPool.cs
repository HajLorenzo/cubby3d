using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private static ObjectPool _instance;
    public static ObjectPool Instance => _instance;

    [SerializeField] private GameObject[] enemyPool;
    private int index;
    private void Awake()
    {
        _instance = this;
        index = 0;
    }

    public GameObject GetEnemy()
    {
        while (enemyPool[index].activeSelf)
        {
            index++;
            if (index == enemyPool.Length)
                index = 0;
        }
        return enemyPool[index];
    }
}
