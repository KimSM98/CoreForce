using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region 설정
    public float Speed_Type0 = 1;//일반 몹
    public float Speed_Type1 = 0;//보스 몹
    public float Speed_Type2 = 1.5f;//장애물
    public float BulletSpeed = 0.5f;
    public float EnemyShootTerm = 1f;    
    #endregion
    #region GameObject
    public GameObject[] EnemyBullets;
    public GameObject[] Cores;//Enemy의 드롭 아이템
    public GameObject[] Enemy1;
    #endregion
    #region Enemy_매번 변하는 값
    public int[] EnemysProperties = new int[] { 0, 1, 2 , 1, 0, 2 };//불, 풀, 물 속성/ 코어의 스프라이트 바꿈
    int[] Enemy1CoreNum= {0,1,2};//0~2Enemy1이 가지고 있는 코어 개수, 스프라이트 바꿈
    float[] XposArr = { -1, 2, -0, -1, 2, 1 };//Enemy의 x좌표
    #endregion
    
    int coreNum=0;
    int iBullet = 0;
    int dropCoreNum=0;//드롭할 코어의 i
    int corePropertyNum=0;
    int iX = 0;
    float moveSpeed;
    float xPos = 0;
    private void Start()
    {
        //core개수 바꾸기
        SetAllObjType();
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
        //여기에 Bullet의 속성
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
    
    void SetAllObjType()
    {
        if (Enemy1.Length > 0)//효력이 없는 부분
        {
            for (int i = 0; i < Enemy1.Length; i++)
            {
                SetObjType(Enemy1[i]);         
            }
        }
    }
    #region Enemy_매번 변하는 값의 함수
    void SetObjType(GameObject Enemy){//EnemyType속성개수변경
        Enemy.GetComponent<Enemy>().SettingObj(0, Enemy1CoreNum[coreNum]);
        Enemy.GetComponent<EnemyCore>().SetActiveCorePos(Enemy1CoreNum[coreNum]);
        //Enemy.GetComponent<EnemyCore>().SetCoreProperties(Enemy1CoreNum[coreNum], GetEnemyCoreProperty());
        /*    
        corePropertyNum++;
        if(corePropertyNum == EnemysProperties.Length)
            corePropertyNum=0;
*/
        coreNum++;
        if (coreNum == Enemy1CoreNum.Length)
            coreNum = 0;
    }

    public void DropCores(Vector3 EnemyPos){
        Cores[dropCoreNum].transform.position = EnemyPos;
        Cores[dropCoreNum].GetComponent<ItemScript>().isMove = true;

        dropCoreNum++;

        if(dropCoreNum == Cores.Length)
            dropCoreNum=0;
    }
    
    public int GetEnemyCoreProperty(){
        return EnemysProperties[corePropertyNum];
    }
    
    #endregion
}
