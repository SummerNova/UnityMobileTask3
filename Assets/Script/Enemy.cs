using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerController controller;
    private GameManager gameManager;
    private bool isDead = false;

    [SerializeField] GameObject Graphic;
    [SerializeField] Rigidbody2D RB;
    [SerializeField] Animator animator;

    [SerializeField] float EnemySpeed = 1;
    [SerializeField] float EnemyHP = 1;
    [SerializeField] float EnemyHPMax = 3;
    [SerializeField] float CollisionDamage = 10;


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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && !isDead) 
        {
            
            gameManager.health.TakeDamage(CollisionDamage);
            Death();
        }

        if (collision.gameObject.tag == "Bullet")
        {
            
            EnemyHP -= gameManager.BulletDamage;
            if (EnemyHP <= 0) Death();
        }
    }

    public void OnEnable()
    {
        EnemyHP = EnemyHPMax;
        animator.SetBool("Destroyed", false);
        isDead = false;
    }

    public void Death()
    {
        GameObject XPOrb = gameManager.XPPool.GetPooledObject();
        isDead = true;
        XPOrb.transform.position = transform.position;
        XPOrb.SetActive(true);
        animator.SetBool("Destroyed", true);
    }
}
