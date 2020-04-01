using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ObjectType = 0;//0: normal Enemy, 1: Boss
    public int coreNum;
    public float moveSpeed = 1f;
    public bool isEnemyLive = true;
    
    private float xPos, yPos;
    private float objectSpeed;
    float getX;
    Vector3 cameraView;
    
    #region Boss
    public int hp=30;
    int hpT=0;
    float xspeed =1f;
    #endregion
    bool isLowHP = false;

    public GameObject ExplosionParticle;

    void Start()
    {
        moveSpeed = GetComponentInParent<EnemyManager>().GetMoveSpeed(ObjectType);
        
        if(ObjectType==1)
            hpT=hp;
         
        objectSpeed = moveSpeed;

        xPos = this.transform.position.x;
        yPos = this.transform.position.y;
    }

    void Update()
    {
        cameraView = Camera.main.WorldToViewportPoint(transform.position);

        if (GameManager.instance.isMoveOn == false)
        {
            moveSpeed = 0;
        }
        else
            moveSpeed = objectSpeed;

        if(GameManager.instance.isPlayerDead == true)
        {
            if(this.CompareTag("Enemy") == true)
            {
                this.gameObject.SetActive(false);
            }
        }
        
        this.transform.Translate(new Vector2(0, moveSpeed * Time.deltaTime));

        if (isEnemyLive == false)
        {
            if(this.ObjectType == 1)
                GameManager.instance.isbossSoundPlayed = false;
            PlayParticle();
            GetComponentInParent<EnemyManager>().DropCores(transform.position, coreNum, this.GetComponent<EnemyCore>().GetEnemyCorePropertyArr());

            this.transform.position = new Vector2(0, -6f);//Relocation
            isEnemyLive = true;
        }

        if (cameraView.y < -0.3f)
        {
            Relocate();            
            GetComponentInParent<EnemyManager>().SetObjType(this.gameObject);
        }

        if(ObjectType == 1){
            
            this.transform.Translate(new Vector2(xspeed* Time.deltaTime, 0));

            if(this.transform.position.x > 1.5f){
                xspeed*=-1;
            }
            else if(this.transform.position.x<0.06f)
                xspeed*=-1;

            if(hp<=10 && !isLowHP){
                StartCoroutine(ShowAngryMode());
                isLowHP = true;
            }
            else if(hp > 10)
            {
               GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
               isLowHP = false;
            }
        }

    }

    void Relocate()
    {
            getX = GetComponentInParent<EnemyManager>().GetXPos();
            this.transform.position = new Vector2(getX, 5.2f);
            GetComponent<EnemyShootBullet>().ResetShootTerm();
    }

    void ChangeEnemySprite()
    {
        this.GetComponent<ObjectTypeScript>().Type = coreNum;
        this.GetComponent<ObjectTypeScript>().ChangeSprite();
    }

    public void SettingObj(int ObjType, int core_Num)
    {
        ObjectType = ObjType;
        if (ObjType == 0){
            coreNum = core_Num;
            ChangeEnemySprite();
        }
        else if(ObjType == 1){
            coreNum = core_Num;
        }
    }

    public void SubBossHp(){
        hp--;
        if(hp<=0){
            PlayParticle();
            this.gameObject.SetActive(false);
            GetComponentInParent<EnemyManager>().DropCores(transform.position, coreNum, this.GetComponent<EnemyCore>().GetEnemyCorePropertyArr());
            GameManager.instance.ResetPropertyCount();                        
            hp=hpT;                        
        }
            
    }
    IEnumerator ShowAngryMode(){
        while(true)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.6f,0,0);
            yield return new WaitForSeconds(0.5f);
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
            yield return new WaitForSeconds(0.5f);
        }
    }
    
    void PlayParticle(){
        ExplosionParticle.transform.position = this.transform.position;
        ExplosionParticle.GetComponent<ParticleSystem>().Play();
    }

    public int GetEnemyObjectType(){
        return ObjectType;
    }
}
