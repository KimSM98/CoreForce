using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIScript : MonoBehaviour
{
    public Text BestScore;
    public GameObject[] SoundButton; //0:On 1:Off
    public GameObject SoundManager;
    public GameObject RuleUI;
    public GameObject BGStars;
    public GameObject PlayerIcon;
    public GameObject AllUI;
    public GameObject QuitGameUI;
    bool isClicked = false;
    bool isPlayerMove = false;
    void Start()
    {
        //PlayerPrefs.SetInt("BestScore", 0);//초기화할때 사용
        BestScore.text = "" + PlayerPrefs.GetInt("BestScore");
        if(PlayerPrefs.GetInt("IsSoundOn") == 1){//Sound On
           PressSoundOffButton();
        }
        else if (PlayerPrefs.GetInt("IsSoundOn") == 0){//SoundOff
            PressSoundOnButton();
        }
        RuleUI.SetActive(false);
        QuitGameUI.SetActive(false);
    }

    void Update()
    {
        if(isPlayerMove == true){
            PlayerIcon.transform.Translate(new Vector3(0,0.2f,0));
            if(PlayerIcon.transform.position.y > 5.25f){
                SceneManager.LoadScene("GamePlayScene");
                isPlayerMove=false;
            }
                
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {   
            AllUI.SetActive(false);
            QuitGameUI.SetActive(true);
        }
    }
    public void GameStartButton()
    {
        AllUI.SetActive(false);
        PlayerIcon.SetActive(true);        
        BGStars.GetComponent<MoveMap>().SetSpeed(20);
        isPlayerMove = true;
        /*PlayerIcon.transform.Translate(new Vector3(0,0.1f,0));
        if(PlayerIcon.transform.position.y > 4.6f)
            SceneManager.LoadScene("GamePlayScene");*/
    }

    public void PressSoundOffButton(){//        
        SoundButton[1].SetActive(false);
        SoundButton[0].SetActive(true);    
        PlayerPrefs.SetInt("IsSoundOn", 0);
        SoundManager.GetComponent<SoundManager>().OnSound();   
    }
    public void PressSoundOnButton(){        
        SoundButton[0].SetActive(false);
        SoundButton[1].SetActive(true);     
        PlayerPrefs.SetInt("IsSoundOn", 1);   
        SoundManager.GetComponent<SoundManager>().OffSound();   
    }
    public void HelpUI(){
        if(isClicked == false){
            RuleUI.SetActive(true);
            isClicked = true;
        }
        else if(isClicked == true){
            RuleUI.SetActive(false);
            isClicked = false;
        }
    }
    public void QuitYes(){
        Application.Quit();
    }
    public void QuitNo(){
        AllUI.SetActive(true);
        QuitGameUI.SetActive(false);
    }
}
