using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBullet : MonoBehaviour
{
    public GameObject shootPos;//bullet발사 위치
    public GameObject[] FireBulletObjs;//bullet sprite
    public GameObject[] GrassBulletObjs;//bullet sprite
    public GameObject[] WaterBulletObjs;//bullet sprite
    
    private int FireBulletNum = 0;
    private int GrassBulletNum = 0;
    private int WaterBulletNum = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShootFire();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootGrass();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ShootWater();
        }
    }

    void ShootFire()
    {
        //bullet을 발사 위치로 이동 시킴
        FireBulletObjs[FireBulletNum].transform.position = new Vector3(shootPos.transform.position.x, shootPos.transform.position.y, 0);
        //bullt을 이동 상태로 바꿈
        FireBulletObjs[FireBulletNum].gameObject.GetComponent<BulletScript>().isMove = true;
        FireBulletNum++;
        if (FireBulletNum == FireBulletObjs.Length)//0으로 초기화
            FireBulletNum = 0;
    }

    void ShootGrass()
    {
        //bullet을 발사 위치로 이동 시킴
        GrassBulletObjs[GrassBulletNum].transform.position = new Vector3(shootPos.transform.position.x, shootPos.transform.position.y, 0);
        //bullt을 이동 상태로 바꿈
        GrassBulletObjs[GrassBulletNum].gameObject.GetComponent<BulletScript>().isMove = true;
        GrassBulletNum++;
        if (GrassBulletNum == GrassBulletObjs.Length)//0으로 초기화
            GrassBulletNum = 0;
    }

    void ShootWater()
    {
        //bullet을 발사 위치로 이동 시킴
        WaterBulletObjs[WaterBulletNum].transform.position = new Vector3(shootPos.transform.position.x, shootPos.transform.position.y, 0);
        //bullt을 이동 상태로 바꿈
        WaterBulletObjs[WaterBulletNum].gameObject.GetComponent<BulletScript>().isMove = true;
        WaterBulletNum++;
        if (WaterBulletNum == WaterBulletObjs.Length)//0으로 초기화
            WaterBulletNum = 0;
    }
}
