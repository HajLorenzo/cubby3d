using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private EnemyData enemyData;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (transform.position.z <= -13)
            Done();
    }

    private void OnEnable()
    {
        rb.DOMoveZ(enemyData.endZpoint, enemyData.speed, false);
    }
    private void Done()
    {
        Spawner.Instance.SpawnEnemy();
        gameObject.SetActive(false);
    }
    public void Hit()
    {
        DOTween.Kill(this);
        Instantiate(enemyData.EnemyDes, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Score")
            GameManager.Instance.ScorePlus();
    }
}
