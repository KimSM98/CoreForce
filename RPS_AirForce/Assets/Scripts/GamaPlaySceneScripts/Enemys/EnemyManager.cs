using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float Speed_Type0 = 1;//일반 몹
    public float Speed_Type1 = 0;//보스 몹
    public float Speed_Type2 = 1.5f;//장애물
    public float BulletSpeed = 0.5f;
    public float EnemyShootTerm = 1f;

    public GameObject[] Enemy1;
    //start에서 랜덤으로 하는 것 추가하기 

    public int[] EnemysProperties = new int[] { 0, 1, 2 , 1, 0, 2  };//불, 풀, 물 속성/ 코어의 스프라이트 바꿈
    int[] Enemy1CoreNum= {0,1};//Enemy1이 가지고 있는 코어 개수, 스프라이트 바꿈
    int coreNum=0;

    public GameObject[] EnemyBullets;
    public GameObject[] Cores;

    int iBullet = 0;
    int iCore = 0;

    //Vector2 bulletShootPos;

    
    float[] XposArr = { -1, 2, -0, -1, 2, 1 };
    float moveSpeed;
    float xPos = 0;
    int iX = 0;

    private void Start()
    {
        //core개수 바꾸기
        SetObjType();
        SetBulletSpeed();
        SetEnemyShootTerm();
        BulletSpeed = Speed_Type0 * 1.5f;
    }
    
    public float GetMoveSpeed(int objectType)
    {
        if (objectType == 0)//일반몹
            moveSpeed = Speed_Type0;
        else if (objectType == 1)//보스몹
            moveSpeed = Speed_Type1;
        else if (objectType == 2)//장애물
            moveSpeed = Speed_Type2;

        return moveSpeed;
    }

    public float GetXPos()
    {
        xPos = XposArr[iX];        
        iX++;
        if (iX == XposArr.Length)
            iX = 0;
        Debug.Log(iX + " l:" + XposArr.Length);
        return xPos;        
    }

    void AddiX()
    {
        iX++;
        if (iX == XposArr.Length)
            iX = 0;
    }
 
    public GameObject GetBullet()
    {
        iBullet++;
        if (iBullet == EnemyBullets.Length)
            iBullet = 0;

        EnemyBullets[iBullet].GetComponent<ObjectTypeScript>().ChangeSprite();
        EnemyBullets[iBullet].GetComponent<BulletScript>().isMove = true;

        return EnemyBullets[iBullet];
    }

    void SetBulletSpeed()
    {
        for(int i=0; i < EnemyBullets.Length; i++)
        {
            EnemyBullets[i].GetComponent<BulletScript>().SetBulletSpeed(BulletSpeed);
        }
    }

    void SetEnemyShootTerm()
    {
        for (int i = 0; i < Enemy1.Length; i++)
        {
            Enemy1[i].GetComponent<EnemyShootBullet>().SetShootTerm(EnemyShootTerm);
        }
    }
    public GameObject GetCore()
    {
        iCore++;
        if (iCore == Cores.Length)
            iCore = 0;

        return Cores[iCore];
    }
    void SetObjType()
    {
        if (Enemy1.Length > 0)//효력이 없는 부분
        {
            for (int i = 0; i < Enemy1.Length; i++)
            {
                Enemy1[i].GetComponent<Enemy>().SettingObj(0, Enemy1CoreNum[coreNum]);
                Enemy1[i].GetComponent<EnemyCore>().SetActiveCorePos(coreNum);

                if (coreNum == 0)
                    GetCore().transform.position = Enemy1[i].transform.position;
                //GetCore().GetComponent<ItemScript>().SetCore(Enemy1[i].GetComponent<EnemyCore>().EnemyCorePos[0].transform.position, Speed_Type0, i);
                //GetCore().transform.position = Enemy1[i].transform.position;

                if (Enemy1CoreNum[coreNum] == Enemy1CoreNum.Length)
                    coreNum = 0;
                coreNum++;
            }
        }
    }
}
