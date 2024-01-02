using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPOrb : MonoBehaviour
{
    private Vector2 DriftDIrection = Vector2.zero;
    private bool isDrifting = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        DriftDIrection = new Vector2((Random.value) * 2 - 1, (Random.value) * 2 - 1).normalized;
        isDrifting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDrifting)
        {
            transform.Translate(DriftDIrection * Time.deltaTime*0.05f);
        }
        else
        {
            transform.Translate((GameManager.instance.controller.transform.position - transform.position).normalized * 10*Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Magnet") isDrifting = false;
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.CollectXP();
            transform.gameObject.SetActive(false);
        }
    }
}
