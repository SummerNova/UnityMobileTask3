using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health { get; set; } = 100;
    private float maxHealth { get; set; } = 100;
    [SerializeField] float RegenRate = 0.1f;
    [SerializeField] Slider HPBar;
    GameManager gameManager;
    private bool alive = true;

    private void Start()
    {
        gameManager = GameManager.instance;
        health = maxHealth;
        StartCoroutine(Alive());
    }
    // Update is called once per frame
    IEnumerator Alive()
    {
        while (alive)
        {
            yield return null;

            UpdateBar();
            if (health < 0)
            {
                gameManager.Death();
                alive = false;
            }

            else
            {
                if (health + RegenRate * gameManager.RegenRank * Time.deltaTime > maxHealth)
                {
                    health = maxHealth;
                }
                else
                {
                    health += RegenRate * gameManager.RegenRank * Time.deltaTime;
                }
            }
            UpdateBar();
        }
    }

    public void UpdateBar()
    {
        HPBar.value = health / maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        UpdateBar();
        if (health < 0)
        {
            gameManager.Death();
            StopCoroutine(Alive());
        }
    }

    public void HealAmount(float amount)
    {
        health += amount;
        UpdateBar();
    }

    public void IncreaseMaxHealth(float amount)
    {
        maxHealth += amount;
        UpdateBar();
    }

    public void DecreaseMaxHealth(float amount)
    {
        maxHealth -= amount;
        if (health > maxHealth) health = maxHealth;
        UpdateBar();
        if (health < 0) gameManager.Death();
    }

    
}
