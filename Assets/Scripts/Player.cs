using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private GameObject PlayerDes; //Destractive
    [SerializeField] private float HitForce, HitRadius;
    [SerializeField] private GameObject hitPrt;
    [SerializeField] private Transform hitPos;
    private bool loseGame;
    private void Awake()
    {
        loseGame = false;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (loseGame)
            return;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            RightMove();
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            LeftMove();
    }
    public void FixedUpdate()
    {
        if (rb.velocity.y < 0)
            rb.velocity += Vector3.up * Physics.gravity.y * (1.5f) * Time.deltaTime;
        else if (rb.velocity.y > 0)
            rb.velocity += Vector3.up * Physics.gravity.y * (1.5f) * Time.deltaTime;
    }
    private void RightMove()
    {
        if (transform.position.x<=-0.95)
            rb.DOMoveX(1, MoveSpeed);
    }
    private void LeftMove()
    {
        if (transform.position.x >= 0.95)
            rb.DOMoveX(-1, MoveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Hit();
            Lose();
        }
        else if (collision.collider.tag == "Ground")
            Destractive();
    }
    private void Lose()
    {
        AudioManager.Instance.Play(1);
        hitPrt.transform.position = transform.position;
        hitPrt.SetActive(true);
        loseGame = true;
        rb.AddExplosionForce(HitForce, hitPos.position, HitRadius);
        Invoke("Delay", 1f);
    }
    public void Destractive()
    {
        AudioManager.Instance.Play(2);
        hitPrt.transform.position = transform.position;
        hitPrt.SetActive(true);
        Instantiate(PlayerDes, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
    public void Delay()
    {
        GameManager.Instance.LoseGame();
    }
}
