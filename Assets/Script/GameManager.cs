using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private int PlayerLevel { get; set; } = 1;
    public float BulletSpeed { get; set; } = 6;

    private float _bulletDelay = 1;
    public float BulletDelay { get { return _bulletDelay; } set { _bulletDelay = value; OnGunChanged.Invoke(); } }

    private int _gunSubdivisions = 1;
    public int GunSubdivisions { get { return _gunSubdivisions; } set { _gunSubdivisions = value; OnGunChanged.Invoke(); } } 
    public float Range { get; set; } = 15;
    public PlayerController controller;

    public static GameManager instance;

    public UnityEvent OnGunChanged;

    private void Awake()
    {
        instance = this;
    }
    
}
