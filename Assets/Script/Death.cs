using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject DeathPanel;
    public void GameOver()
    {
        DeathPanel.SetActive(true);
    }
}
