using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField] RectTransform[] Upgrades;
    [SerializeField] Button[] UpgradeButtons;
    [SerializeField] GameObject UpgradesPanel;
    GameManager gameManager;

    private void Start()
    {
        
        shuffle();
        
        gameManager = GameManager.instance;
        
        disableButtons();

        UpgradesPanel.SetActive(false);
    }

    public void UpgradeHP()
    {
        gameManager.health.IncreaseMaxHealth(10);
        gameManager.LevelupBank--;
        shuffle();
        if (gameManager.LevelupBank < 0 ) disableButtons();
    }

    public void UpgradeBPS()
    {
        gameManager.BulletDelay *= 2;
        gameManager.LevelupBank--;
        shuffle();
        if (gameManager.LevelupBank < 0) disableButtons();
    }

    public void UpgradeDamage()
    {
        gameManager.BulletDamage += 1;
        gameManager.LevelupBank--;
        shuffle();
        if (gameManager.LevelupBank < 0) disableButtons();
    }

    public void UpgradeSpread()
    {
        gameManager.GunSubdivisions += 1;
        gameManager.LevelupBank--;
        shuffle();
        if (gameManager.LevelupBank < 0) disableButtons();
    }

    public void UpgradeRegen()
    {
        gameManager.RegenRank += 1;
        gameManager.LevelupBank--;
        shuffle();
        if (gameManager.LevelupBank < 0) disableButtons();
    }

    public void UpgradeSpeed()
    {
        gameManager.controller.Speed += 0.5f;
        gameManager.LevelupBank--;
        shuffle();
        if (gameManager.LevelupBank < 0) disableButtons();
    }

    public void UpgradeMagnet()
    {
        gameManager.Magnet.radius += 0.5f;
        gameManager.LevelupBank--;
        shuffle();
        if (gameManager.LevelupBank < 0) disableButtons();
    }

    void disableButtons()
    {
        foreach (Button button in UpgradeButtons) {
            button.interactable = false;
        }
    }

    public void enableButtons()
    {
        foreach (Button button in UpgradeButtons) { button.interactable = true; }
    }

    public void TogglePause()
    {
        Time.timeScale = Mathf.Abs(Time.timeScale-1);
        UpgradesPanel.SetActive(!UpgradesPanel.activeInHierarchy);
    }


    public void shuffle()
    {

        for (int i = 0; i < Upgrades.Length; i++)
        {
            int k = UnityEngine.Random.Range(0, Upgrades.Length);

            RectTransform temp = Upgrades[i];
            Upgrades[i] = Upgrades[k];
            Upgrades[k] = temp;
        }
            
     

        Upgrades[0].anchoredPosition = new Vector3(0,400,0);
        Upgrades[0].gameObject.SetActive(true);

        Upgrades[1].anchoredPosition = new Vector3(0, 150, 0);
        Upgrades[1].gameObject.SetActive(true);

        Upgrades[2].anchoredPosition = new Vector3(0, -100, 0);
        Upgrades[2].gameObject.SetActive(true);

        Upgrades[3].anchoredPosition = new Vector3(0, -350, 0);
        Upgrades[3].gameObject.SetActive(true);

        for (int i = 4; i < Upgrades.Length; i++)
        {
            Upgrades[i].gameObject.SetActive(false);
        }
        
    }
}
