using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public int ObjectType = 1;//
    public float moveSpeed = 1;
    public int movingNum = 0; //좌표 넘버링
    public bool isEnemyLive = true;//Enemy가 살아있는지의 여부, 이름 수정할 예정
    //public bool isMoveOn = true;//움직이는 상황인지 체크

    private float xPos, yPos;
    private float[] arrXPos;
    private int arrNum = 0;
    private float objectSpeed;//object마다 public으로 다른 스피드를 갖고 있기 때문에

    float getX;

    Vector3 cameraView;

    public int coreNum;

    void Awake()
    {
        moveSpeed = GetComponentInParent<EnemyManager>().GetMoveSpeed(ObjectType);
        //ObjectType = GetComponentInParent<EnemyManager>().
        
    }

    void Start()
    {
        if (ObjectType == 0)
        {
            ChangeEnemySprite();
        }
        Debug.Log(cameraView.y + " " );
        
        objectSpeed = moveSpeed;//isMoveOn이 false에서 true로 바뀔때 원래의 속도를 받기위한 저장 변수

        //원래 있던 위치 받음
        xPos = this.transform.position.x;
        yPos = this.transform.position.y;
        //Cloud Position
        /*if(this.movingNum == 0)
            arrXPos = new float[] { 1f, 2.5f, 3f, -2f, 0.5f, -0.5f }; 
        else if (this.movingNum == 1)
            arrXPos = new float[] { 2.5f, 0.5f, -1f, 2.5f, -2f, 3f };
        else if (this.movingNum == 2)
            arrXPos = new float[] { -1f, -2f, 1f, -0.5f, 1f, 1.5f };
            */

        //Enemy Position
        if (this.movingNum == 3)
            arrXPos = new float[] { -1f, 0f, 1f, 2f };
        else if (this.movingNum == 4)
            arrXPos = new float[] { 2f, 1.5f, -1f, -2f };
        
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

        if (isEnemyLive == false)
        {
            print("주금");
            this.transform.position = new Vector2(0, -6f);//카메라 밖으로 나가게해서 Relocation
            isEnemyLive = true;
        }

        if (cameraView.y < -0.3f)
        {//카메라 아래로 나가면, x좌표 이동, y좌표를 위로 이동        
            Relocate();
        }
        
        if(arrNum == arrXPos.Length)
            arrNum = 0;
    }

    void Relocate()
    {
            getX = GetComponentInParent<EnemyManager>().GetXPos();
            this.transform.position = new Vector2(getX, 6f);//여기를 변경
    }

    void ChangeEnemySprite()
    {
        this.GetComponent<ObjectTypeScript>().Type = coreNum;
        this.GetComponent<ObjectTypeScript>().ChangeSprite();
    }

    public void SettingObj(int ObjType, int core_Num)
    {
        ObjectType = ObjType;
        if (ObjType == 0)
            coreNum = core_Num;
        ChangeEnemySprite();
        Debug.Log("coreNum:" + coreNum);
    }
}
