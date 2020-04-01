using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    #region 설정Setting    
    public float[] Speed = new float[3]{2.5f, 0, 1.5f};    
    public float BulletSpeed = 0.5f;
    public float EnemyShootTerm = 1f;   // 1, 0.75, 0.5 
    public float BossShootTerm = 0.75f;
    public float AppearMeteorTerm = 10f;
    #endregion

    #region GameObject
    public GameObject BossEnemy;
    public GameObject[] Enemy1;
    public GameObject[] Meteors;
    public GameObject[] EnemyBullets;
    public GameObject[] Cores;//Enemy's Core Item
    public GameObject[] BossSkillBullet;
    #endregion

    #region Enemy_매번 변하는 값
    public int[] EnemysProperties = new int[] { 0, 1, 2 , 1, 0, 2 };//0: fire, 1: Grass, 2: Water 
  
    int[] Enemy1CoreNum= {0,1,2};
    float[] XposArr = { -1, 1.75f, -0.3f, 1.2f, -1, 2, 0.3f, 1.2f, 2.4f };//Enemy's xPos
    //-1, -0.3, 0.5 1.2 1.75 2.4
    float[] MeteorsXpos = {-1.1f, 2.0f, 0, 1.5f};
    int meteorPosNum = 0;
    #endregion
    
    int coreNum=0;
    int iBullet = 0;
    int sBullet =0;
    int dropCoreNum=0;
    int corePropertyNum=-1;
    int iX = 0;
    float moveSpeed;
    float xPos = 0;
    GameObject core;
    int difficulty=0;
    
    private void Start()
    {
        instance = this;

        BossEnemy.SetActive(false);
        SetAllObjType();
        SetBulletSpeed();
        SetEnemyShootTerm();
        
        BulletSpeed = Speed[0] * 1.5f;
        BossEnemy.GetComponent<EnemyShootBullet>().SetShootTerm(BossShootTerm);
    
    }
    public float GetMoveSpeed(int objectType)
    {   
        return Speed[objectType];        
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
            
        EnemyBullets[iBullet].GetComponent<ObjectTypeScript>().Changetype(type);
        EnemyBullets[iBullet].GetComponent<BulletScript>().isMove = true;

        return EnemyBullets[iBullet];
    }

    public GameObject GetBossSkillBullet(int type){
        sBullet++;
        if (sBullet == BossSkillBullet.Length)
            sBullet = 0;
        BossSkillBullet[sBullet].GetComponent<ObjectTypeScript>().Changetype(type);
        BossSkillBullet[sBullet].GetComponent<BulletScript>().isMove = true;

        return BossSkillBullet[sBullet];
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
        if (Enemy1.Length > 0)
        {
            for (int i = 0; i < Enemy1.Length; i++)
            {
                SetObjType(Enemy1[i]);         
            }
        }
        SetBossData();
    }
    #region Enemy_매번 변하는 값의 함수
    public void SetObjType(GameObject Enemy){
        Enemy.GetComponent<EnemyCore>().OffCores();
        Enemy.GetComponent<Enemy>().SettingObj(0, Enemy1CoreNum[difficulty]);
        Enemy.GetComponent<EnemyCore>().SetActiveCorePos(Enemy1CoreNum[difficulty]);

    }

    void SetBossData(){
        BossEnemy.GetComponent<Enemy>().SettingObj(1, 2);
        BossEnemy.GetComponent<EnemyCore>().SetActiveCorePos(2);
    }

    public void DropCores(Vector3 EnemyPos, int coreNum, int[] cores){
        for(int i=0; i < coreNum+1; i++){            
            GetCoreObj();
            core.GetComponent<ObjectTypeScript>().Changetype(cores[i]);
            
            float rand = Random.Range(-0.25f,0.25f);
            if(i==0)
                core.transform.position = new Vector3(EnemyPos.x, EnemyPos.y);
            else
                core.transform.position = new Vector3(EnemyPos.x+rand, EnemyPos.y+rand);
            core.GetComponent<ItemScript>().isMove = true;
        }       
    }
    
    public int GetEnemyCoreProperty(){
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
        if(difficulty == 1){
            EnemyShootTerm = 0.85f;
            Meteors[0].SetActive(true);
            Meteors[0].GetComponent<MeteorScript>().AppearMeteror(AppearMeteorTerm);
        }
            
        else if(difficulty ==2){
            EnemyShootTerm = 0.75f;
            Meteors[1].SetActive(true);
            Meteors[1].GetComponent<MeteorScript>().AppearMeteror(AppearMeteorTerm);
            Meteors[2].SetActive(true);
            Meteors[2].GetComponent<MeteorScript>().AppearMeteror(AppearMeteorTerm);
        
        }          
            
        SetEnemyShootTerm();
    }

    public float GetMeteorPos(){
        int num = meteorPosNum;
        meteorPosNum++;
        if(meteorPosNum == MeteorsXpos.Length)
            meteorPosNum = 0;

        return MeteorsXpos[num];
    }
}
