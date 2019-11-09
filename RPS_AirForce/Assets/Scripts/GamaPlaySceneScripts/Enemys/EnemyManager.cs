using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float Speed_Type0 = 1;//일반 몹
    public float Speed_Type1 = 0;//보스 몹
    public float Speed_Type2 = 1.5f;//장애물

    public GameObject[] Enemy1;
    //start에서 랜덤으로 하는 것 추가하기 
    public int[,] EnemysProperties = new int[2, 3] { { 0, 1, 2 }, { 2, 0, 1 } };


    int[] Enemy1CoreNum;//코어 개수


    public GameObject[] EnemyBullets;
    public float EnemyShootTerm = 1f;

    float[] XposArr = { -2, 1, -1, 2, 0, 1 };
    float moveSpeed;
    float xPos = 0;
    int iX = 0;

    private void Start()
    {
        int[] Enemy1CoreNum = { 1, 2 };
        if (Enemy1.Length > 0)//효력이 없는 부분
        {
            for (int i = 0; i < Enemy1.Length; i++)
            {
                Enemy1[i].GetComponent<Move>().SettingObj(0, Enemy1CoreNum[i]);
                
                Debug.Log("ENCN: " + Enemy1CoreNum[i]);
            }
        }
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

    public void AddiX()
    {
        iX++;
        if (iX == XposArr.Length)
            iX = 0;
    }
    /*
    void ShootEnemyBullet()
    {
        for(int i=0; i)
        EnemyBullets[iBullet].transform.position = new Vector2(Enemy1[i].transform.position.x, shootPos.transform.position.y);
        EnemyBullets[iBullet].GetComponent<BulletScript>().isMove = true;
    }*/
    void SetEnemyShootTerm()
    {

    }
}
