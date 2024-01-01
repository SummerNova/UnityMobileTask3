using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController controller;
    private GameManager gameManager;

    [SerializeField] GameObject Graphic;
    [SerializeField] Rigidbody2D RB;
    [SerializeField] Animator animator;

    [SerializeField] float EnemySpeed = 1;
    [SerializeField] float EnemyHP = 1;
    [SerializeField] float EnemyHPMax = 3;


    private void OnValidate()
    {
        if (EnemySpeed < 1) EnemySpeed = 1;
        if (Graphic == null || RB == null) throw new MissingReferenceException();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        controller = gameManager.controller;
        EnemyHP = EnemyHPMax;
    }

    // Update is called once per frame
    void Update()
    {
        Graphic.transform.up = (controller.transform.position - transform.position).normalized;
        RB.MovePosition(transform.position + (controller.transform.position - transform.position).normalized * EnemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Detected SOme COllision");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Colided with Player");
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit By Bullet");
            EnemyHP -= gameManager.BulletDamage;
            if (EnemyHP <= 0) animator.SetBool("Destroyed", true);
        }
    }

    public void Reset()
    {
        EnemyHP = EnemyHPMax;
        animator.SetBool("Destroyed", false);
    }
}
