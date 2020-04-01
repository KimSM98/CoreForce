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

    public bool isPlayerDead = false;
    public int playerScore = 0;
    public int PlayerBestScore=0;
    public bool isMoveOn = true;
    
    int[] coresPropertyCount = {0,0,0};
    public GameObject[] AttackButtons;
    public bool isBossFever = false;
    public Image[] BossUI;
    public int BossSpawnNum=4;
    public int difficulty = 0; //0:Easy 1: Medium 2: Hard
    public GameObject difficultyUI;
    public bool isbossSoundPlayed = false;
    
    void Awake() {
        GameManager.instance = this;
    }
    void Start()
    {
        isPlayerDead = false;     
        isMoveOn = true;
        for(int i=0; i<3; i++){
            BossUI[i].gameObject.SetActive(false);
        }
        playerScore = 0;
    }

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
    
    public void AddcheatScore(){//Cheat
        AddScore(3000);
    }

    public void AddPropertyCount(int type){
        coresPropertyCount[type] +=1;
        AttackButtons[type].GetComponent<ButtonSprite>().NextSprite(coresPropertyCount[type]);

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
            isBossFever=true;
            Debug.Log("보스 등장");
        }
        
        if(isBossFever == true){            
            if(isbossSoundPlayed == false){
                SoundManager.instance.BossAppearSound();
                isbossSoundPlayed = true;
            }                
            EnemyManager.GetComponent<EnemyManager>().AppearBoss();
            isBossFever = false;
        }
    }

    public void ResetPropertyCount()
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
