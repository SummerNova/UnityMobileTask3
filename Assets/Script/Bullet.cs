using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameManager gameManager;
    private int Hits = 0;

    private void Start()
    {
        gameManager = GameManager.instance;
    }


    private void Update()
    {
        transform.Translate(transform.up*gameManager.BulletSpeed*Time.deltaTime);
        if(Vector3.Distance(transform.position,gameManager.controller.transform.position)>gameManager.Range) transform.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Hits = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Hits++;
            if(Hits >= (gameManager.BulletDamage)) transform.gameObject.SetActive(false);
        }
    }
}
