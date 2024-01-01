using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        StartCoroutine(FireWeapon());
    }


    IEnumerator FireWeapon()
    {
        while (true)
        {
            yield return new WaitForSeconds(gameManager.BulletDelay);
            FireBullet();
            RotateWeapon();
        }
    }

    private void RotateWeapon()
    {
        transform.Rotate(new Vector3(0, 0, 45 / gameManager.GunSubdivisions));
    }

    private void FireBullet()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }

    public void ResetGun()
    {
        transform.rotation = Quaternion.identity;
    }

    
}
