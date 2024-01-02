using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int PlayerLevel { get; set; } = 1;

    private int XPPerLevel { get; set; } = 5;

    private int XPBank { get; set; } = 0;

    public int LevelupBank { get; set; } = 0;

    public float BulletSpeed { get; set; } = 6;

    private float _bulletDelay = 1;
    public float BulletDelay { get { return _bulletDelay; } set { _bulletDelay = value; OnGunChanged.Invoke(); } }

    private int _gunSubdivisions = 1;
    public int GunSubdivisions { get { return _gunSubdivisions; } set { _gunSubdivisions = value; OnGunChanged.Invoke(); } } 
    public float Range { get; set; } = 15;

    public float BulletDamage { get; set; } = 1;

    public float RegenRank { get; set; } = 0;

    public PlayerController controller;
    public PlayerHealth health;
    public Slider XPBar;
    public ObjectPool XPPool;
    public UpgradesManager UpgradesManager;
    public CircleCollider2D Magnet;
    public Animator PlayerDeath;

    public static GameManager instance;

    public UnityEvent OnGunChanged;

    private void Awake()
    {
        instance = this;
    }

    public void CollectXP()
    {
        
        XPBank++;
        if (XPBank >= PlayerLevel * XPPerLevel)
        {
            XPBank -= PlayerLevel * XPPerLevel;
            LevelupBank++;
            PlayerLevel++;
            UpgradesManager.enableButtons();
        }
        XPBar.value = (float)XPBank/(float)(PlayerLevel*XPPerLevel);
    }

    public void Death() { PlayerDeath.SetBool("Dead", true); }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    
}
