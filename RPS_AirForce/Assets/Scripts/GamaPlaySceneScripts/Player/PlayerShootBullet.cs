using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBullet : MonoBehaviour
{
    public GameObject[] Bullets;
    public GameObject shootPos;//bullet발사 위치

    int i = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShootFire();
            ShootBullet();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootGrass();
            ShootBullet();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ShootWater();
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        Bullets[i].GetComponent<ObjectTypeScript>().ChangeSprite();
        Bullets[i].transform.position = new Vector2(shootPos.transform.position.x, shootPos.transform.position.y);
        Bullets[i].GetComponent<BulletScript>().isMove = true;
        i++;
        if (i == Bullets.Length)
            i = 0;
    }

    void ShootFire()
    {
        Bullets[i].GetComponent<ObjectTypeScript>().Type = 0;
    }

    void ShootGrass()
    {
        Bullets[i].GetComponent<ObjectTypeScript>().Type = 1;
    }

    void ShootWater()
    {
        Bullets[i].GetComponent<ObjectTypeScript>().Type = 2;
    }

    public void Button0Shoot()
    {
        ShootFire();
        ShootBullet();
    }
    public void Button1Shoot()
    {
        ShootGrass();
        ShootBullet();
    }
    public void Button2Shoot()
    {
        ShootWater();
        ShootBullet();
    }
}
