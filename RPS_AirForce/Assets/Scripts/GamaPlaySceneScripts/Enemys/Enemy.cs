using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int ObjectType = 0;//0: 일반, 1: 보스, 2: 장애물
    public float moveSpeed = 1;
    public bool isEnemyLive = true;//Enemy가 살아있는지의 여부, 이름 수정할 예정
    //public bool isMoveOn = true;//움직이는 상황인지 체크

    private float xPos, yPos;

    private float objectSpeed;//object마다 public으로 다른 스피드를 갖고 있기 때문에

    float getX;

    Vector3 cameraView;

    public int coreNum;
    #region Boss
    public int hp=30;
    int hpT=0;
    float xspeed =0.05f;
    #endregion
    bool isLowHP = false;
    void Awake()
    {
        moveSpeed = GetComponentInParent<EnemyManager>().GetMoveSpeed(ObjectType);
        //ObjectType = GetComponentInParent<EnemyManager>().
        
    }

    void Start()
    {
        if(ObjectType==1)
            hpT=hp;
        //ChangeEnemySprite();
        Debug.Log(cameraView.y + " " );
        
        objectSpeed = moveSpeed;//isMoveOn이 false에서 true로 바뀔때 원래의 속도를 받기위한 저장 변수

        //원래 있던 위치 받음
        xPos = this.transform.position.x;
        yPos = this.transform.position.y;
    
    }

    // Update is called once per frame
    void Update()
    {
        cameraView = Camera.main.WorldToViewportPoint(transform.position);

        if (GameManager.instance.isMoveOn == false)//움직이는 상황이 아닐경우 움직이지 않게 speed를 0으로 바꿈
        {
            moveSpeed = 0;
        }
        else
            moveSpeed = objectSpeed;

        if(GameManager.instance.isPlayerDead == true)//Gameover상황이면
        {
            if(this.CompareTag("Enemy") == true)//Enemy가 안보이게
            {
                this.gameObject.SetActive(false);//끔
            }
        }
        
        //GameObject가 계속 아래로 내려가게 
        this.transform.Translate(new Vector2(0, moveSpeed * 0.1f));

        if (isEnemyLive == false)//Enemy죽음
        {
            GetComponentInParent<EnemyManager>().DropCores(transform.position, coreNum, this.GetComponent<EnemyCore>().GetEnemyCorePropertyArr());

            this.transform.position = new Vector2(0, -6f);//카메라 밖으로 나가게해서 Relocation
            isEnemyLive = true;
        }

        if (cameraView.y < -0.3f)//카메라 아래로 내려가면
        {//카메라 아래로 나가면, x좌표 이동, y좌표를 위로 이동    
            Relocate();
            //리셋
            GetComponentInParent<EnemyManager>().SetObjType(this.gameObject);//죽었을때와도 같은 상황
        }

        if(ObjectType == 1){
            
            this.transform.Translate(new Vector2(0.1f*xspeed, 0));

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
            this.transform.position = new Vector2(getX, 6f);//몬스터 스폰 텀을 넣고 싶으면 여기를 변경
            
    }

    void ChangeEnemySprite()
    {
        this.GetComponent<ObjectTypeScript>().Type = coreNum;
        this.GetComponent<ObjectTypeScript>().ChangeSprite();
    }

    public void SettingObj(int ObjType, int core_Num)//Enemy1(일반몬스터), 코어개수
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
            this.gameObject.SetActive(false);
            GetComponentInParent<EnemyManager>().DropCores(transform.position, coreNum, this.GetComponent<EnemyCore>().GetEnemyCorePropertyArr());
            GameManager.instance.ResetPropertyCount();
            //instance.GetComponent<GameManager>().ResetPropertyCount();            
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
    
}
