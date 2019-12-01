using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//추가- 게임 오버되면 Enemy안보이게
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject EnemyManager;
    public GameObject[] OffObjects;

    public bool isPlayerDead = false;//플레이어가 살아있는지의 여부
    public int playerScore = 0;
    public bool isMoveOn = true;//움직이는 상황인지 체크
    

////작업중
    int[] coresPropertyCount = {0,0,0};
    public GameObject[] AttackButtons;
    public bool isBossFever = false;//보스 등장 여부

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isPlayerDead = false;//게임이 시작될때 초기화        
        isMoveOn = true;//시작할때는 움직임ON

        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDead == true)
        {
            OffObject();
        }

    }
    void OffObject()
    {
        for (int i = 0; i < OffObjects.Length; i++)
            OffObjects[i].SetActive(false);
            
    }

    public void AddScore(int score, int coreType){
        playerScore+=score;
        AddPropertyCount(coreType);
        //버튼 초기화
        
    }

    void AddPropertyCount(int type){
        coresPropertyCount[type] +=1;
        AttackButtons[type].GetComponent<ButtonSprite>().NextSprite(coresPropertyCount[type]);//속성별 카운트를 넣어줌

        if(coresPropertyCount[0] >= 4 && coresPropertyCount[1] >= 4 && coresPropertyCount[2] >= 4){
            isBossFever=true;//보스 등장
            ////임시
            coresPropertyCount[0] = 0;
            coresPropertyCount[1] = 0;
            coresPropertyCount[2] = 0;
            EnemyManager.GetComponent<EnemyManager>().AppearBoss();
            Debug.Log("보스 등장");
        }
            
        
        Debug.Log("Core: " + coresPropertyCount[0] + " " + coresPropertyCount[1] + " " +coresPropertyCount[2]);
    }

    void ResetPropertyCount()//보스 잡으면 초기화
    {
        for(int i=0; i<3; i++){
            coresPropertyCount[i] = 0;
        }
    }
}
