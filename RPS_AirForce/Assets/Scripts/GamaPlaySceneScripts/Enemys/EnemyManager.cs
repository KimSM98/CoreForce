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
    public float EnemyShootTerm = 1f;   // 1, 0.75, 0.5 
    public float BossShootTerm = 0.75f;
    #endregion
    #region GameObject
    public GameObject BossEnemy;
    public GameObject[] Enemy1;
    public GameObject[] EnemyBullets;
    public GameObject[] Cores;//Enemy의 드롭 아이템
    
    #endregion
    #region Enemy_매번 변하는 값
    public int[] EnemysProperties = new int[] { 0, 1, 2 , 1, 0, 2 };//불, 풀, 물 속성/ 코어의 스프라이트 바꿈
    //public int[] EnemysProperties = new int[] { 0, 0, 0 , 0, 0, 0 };//불, 풀, 물 속성/ 코어의 스프라이트 바꿈

    int[] Enemy1CoreNum= {0,1,2};
    //int[,] Enemy1CoreNum= {{0,0,0,0}, {1,0,1,1}, {2,1,2,2}};//0~2Enemy1이 가지고 있는 코어 개수, 스프라이트 바꿈
    float[] XposArr = { -1, 1.75f, -0.3f, 1.2f, -1, 2, 0.3f, 1.2f, 2.4f };//Enemy의 x좌표
    //-1, -0.3, 0.5 1.2 1.75 2.4
    #endregion
    
    int coreNum=0;
    int iBullet = 0;
    int sBullet =0;
    int dropCoreNum=0;//드롭할 코어의 i
    int corePropertyNum=-1;
    int iX = 0;
    float moveSpeed;
    float xPos = 0;
    GameObject core;
    public GameObject[] SkillBullet;

    //작업중
    int difficulty=0;
    private void Start()
    {
        //core개수 바꾸기
        BossEnemy.SetActive(false);
        SetAllObjType();
        SetBulletSpeed();
        SetEnemyShootTerm();
        BulletSpeed = Speed_Type0 * 1.5f;

        BossEnemy.GetComponent<EnemyShootBullet>().SetShootTerm(BossShootTerm);
    
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
        return xPos;        
    }

    void AddiX()
    {
        iX++;
        if (iX == XposArr.Length)
            iX = 0;
    }
 
    public GameObject GetBullet(int type)
    {
        iBullet++;
        if (iBullet == EnemyBullets.Length)
            iBullet = 0;
        //여기에 Bullet의 속성
        EnemyBullets[iBullet].GetComponent<ObjectTypeScript>().Changetype(type);
        //EnemyBullets[iBullet].GetComponent<ObjectTypeScript>().ChangeSprite();
        EnemyBullets[iBullet].GetComponent<BulletScript>().isMove = true;

        return EnemyBullets[iBullet];
    }

    public GameObject GetSkillBullet(int type){
        sBullet++;
        if (sBullet == SkillBullet.Length)
            sBullet = 0;
        SkillBullet[sBullet].GetComponent<ObjectTypeScript>().Changetype(type);
        SkillBullet[sBullet].GetComponent<BulletScript>().isMove = true;

        return SkillBullet[sBullet];
    }

    void SetBulletSpeed()
    {
        for(int i=0; i < EnemyBullets.Length; i++)
        {
            EnemyBullets[i].GetComponent<BulletScript>().SetBulletSpeed(BulletSpeed);
        }
    }
    void SetEnemyShootTerm()//난이도 바뀌면 바뀜
    {
        for (int i = 0; i < Enemy1.Length; i++)
        {
            Enemy1[i].GetComponent<EnemyShootBullet>().SetShootTerm(EnemyShootTerm);
        }
        
    }
    
    void SetAllObjType()
    {
        if (Enemy1.Length > 0)//예외처리
        {
            for (int i = 0; i < Enemy1.Length; i++)
            {
                SetObjType(Enemy1[i]);         
            }
        }
        SetBossData();
    }
    #region Enemy_매번 변하는 값의 함수
    public void SetObjType(GameObject Enemy){//EnemyType속성개수변경
        Enemy.GetComponent<EnemyCore>().OffCores();
        Enemy.GetComponent<Enemy>().SettingObj(0, Enemy1CoreNum[difficulty]);
        Enemy.GetComponent<EnemyCore>().SetActiveCorePos(Enemy1CoreNum[difficulty]);

        /*Enemy.GetComponent<Enemy>().SettingObj(0, Enemy1CoreNum[coreNum]);
        Enemy.GetComponent<EnemyCore>().SetActiveCorePos(Enemy1CoreNum[coreNum]);

        coreNum++;
        if(coreNum == Enemy1CoreNum.Length)
            coreNum = 0;*/
    }
    //보스 작업중
    void SetBossData(){
        BossEnemy.GetComponent<Enemy>().SettingObj(1, 2);
        BossEnemy.GetComponent<EnemyCore>().SetActiveCorePos(2);
    }
    public void DropCores(Vector3 EnemyPos, int coreNum, int[] cores){
        for(int i=0; i < coreNum+1; i++){            
            GetCoreObj();
            core.GetComponent<ObjectTypeScript>().Changetype(cores[i]);
            core.transform.position = new Vector3(EnemyPos.x, EnemyPos.y+ i*0.4f);
            //core.transform.position = EnemyPos;
            core.GetComponent<ItemScript>().isMove = true;
        }       
    }
    
    public int GetEnemyCoreProperty(){//접근        //나중에 위에 변수에 -1이라고 한것 고치기
        corePropertyNum++;

        if(corePropertyNum == EnemysProperties.Length)
            corePropertyNum = 0;

        return EnemysProperties[corePropertyNum];
    }

    void GetCoreObj(){
        core = Cores[dropCoreNum];
        
        dropCoreNum++;
        if(dropCoreNum == Cores.Length)
            dropCoreNum=0;
    }

    public void AppearBoss(){
        BossEnemy.gameObject.SetActive(true);
    }
    
    #endregion

    public void changeDifficulty(int num){
        difficulty = num;
        if(difficulty == 1)
            EnemyShootTerm = 0.75f;
        else if(difficulty ==2)
            EnemyShootTerm = 0.5f;
            
        SetEnemyShootTerm();
    }

    
}
