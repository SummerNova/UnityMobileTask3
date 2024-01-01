using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }


    private void Update()
    {
        transform.Translate(transform.up*gameManager.BulletSpeed*Time.deltaTime);
        if(Vector3.Distance(transform.position,gameManager.controller.transform.position)>gameManager.Range) transform.gameObject.SetActive(false);
    }
}
