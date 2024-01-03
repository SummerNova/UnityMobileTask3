using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] ObjectPool objectPool;
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
            yield return new WaitForSeconds(1/ gameManager.BulletDelay);
            for (int i = 0; i < gameManager.GunSubdivisions; i++)
            {
                RotateWeapon(360f / gameManager.GunSubdivisions);
                FireBullet();
            }
            RotateWeapon(45);
        }
    }

    private void RotateWeapon(float degree)
    {
        transform.Rotate(new Vector3(0, 0, degree / gameManager.GunSubdivisions));
    }

    private void FireBullet()
    {
        GameObject bullet = objectPool.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.rotation = transform.rotation;
            bullet.transform.position = transform.position;
            bullet.transform.Translate(transform.up);
            bullet.SetActive(true);
        }
    }

    public void ResetGun()
    {
        transform.rotation = Quaternion.identity;
    }

    
}
