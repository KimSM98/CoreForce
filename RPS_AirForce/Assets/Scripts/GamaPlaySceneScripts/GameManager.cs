using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//추가- 게임 오버되면 Enemy안보이게
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject EnemyManager;
    public GameObject[] OffObjects;

    public bool isPlayerDead = false;//플레이어가 살아있는지의 여부
    public int playerScore = 0;
    public int PlayerBestScore=0;
    public bool isMoveOn = true;//움직이는 상황인지 체크
    
    int[] coresPropertyCount = {0,0,0};
    public GameObject[] AttackButtons;
    public bool isBossFever = false;//보스 등장 여부
    public Image[] BossUI;
    public int BossSpawnNum=4;
//작업중
    public int difficulty = 0; //0:Easy 1: Medium 2: Hard
    public GameObject difficultyUI;

    void Awake()
    {
        Debug.Log("저장"+ PlayerPrefs.HasKey("BestScore") + PlayerPrefs.GetInt("BestScore"));
        instance = this;
    }

    void Start()
    {
        isPlayerDead = false;//게임이 시작될때 초기화        
        isMoveOn = true;//시작할때는 움직임ON
        for(int i=0; i<3; i++){
            BossUI[i].gameObject.SetActive(false);
        }
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerDead == true)
        {
            OffObject();
            GetComponent<MainManager>().SaveScore(playerScore);
        }

    }
    void OffObject()
    {
        for (int i = 0; i < OffObjects.Length; i++)
            OffObjects[i].gameObject.SetActive(false);
            
    }

    public void AddScore(int score){
        playerScore+=score;
        //AddPropertyCount(coreType);

        if(difficulty < 1){
            if(playerScore>=5000){
                difficulty = 1;
                EnemyManager.GetComponent<EnemyManager>().changeDifficulty(difficulty);       
                difficultyUI.GetComponent<ChangeUIScript>().ChangeImage(difficulty);         
            }
        }
        if(difficulty < 2){
            
            if(playerScore>=10000){
                difficulty =2;
                EnemyManager.GetComponent<EnemyManager>().changeDifficulty(difficulty);       
                difficultyUI.GetComponent<ChangeUIScript>().ChangeImage(difficulty);
            }
        }
        
        
        
    }
    /////ㅊㅊㅊㅊ치트
    public void AddcheatScore(){
        AddScore(3000);
    }
    public void AddPropertyCount(int type){
        coresPropertyCount[type] +=1;
        AttackButtons[type].GetComponent<ButtonSprite>().NextSprite(coresPropertyCount[type]);//속성별 카운트를 넣어줌

        if(coresPropertyCount[0] >= BossSpawnNum){
            BossUI[0].gameObject.SetActive(true);
        }
        if(coresPropertyCount[1] >= BossSpawnNum){
            BossUI[1].gameObject.SetActive(true);
        }
        if(coresPropertyCount[2] >= BossSpawnNum){
            BossUI[2].gameObject.SetActive(true);
        }
        if(coresPropertyCount[0] >= BossSpawnNum && coresPropertyCount[1] >= BossSpawnNum && coresPropertyCount[2] >= BossSpawnNum){
            isBossFever=true;//보스 등장
            Debug.Log("보스 등장");
        }
        if(isBossFever == true){            
            SoundManager.instance.BossAppearSound();
            EnemyManager.GetComponent<EnemyManager>().AppearBoss();
            isBossFever = false;
        }
            
        
        //Debug.Log("Core: " + coresPropertyCount[0] + " " + coresPropertyCount[1] + " " +coresPropertyCount[2]);
    }

    public void ResetPropertyCount()//보스 잡으면 초기화
    {
        for(int i=0; i<3; i++){
            coresPropertyCount[i] = 0;
            BossUI[i].gameObject.SetActive(false);
        }
    }
    public void Pause(){
        Debug.Log("정지버튼"+Time.timeScale);

        if(Time.timeScale == 1)
            Time.timeScale = 0;
        else if(Time.timeScale == 0)
            Time.timeScale = 1;
    }
}
