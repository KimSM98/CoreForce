using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay_UIScript : MonoBehaviour
{
    public Canvas GameUICanvas;
    public Text playerScoreText;
    public Text BestScoreText;
    public GameObject GameOverUI;
    public Text[] GameOverTexts;
    public GameObject AttackButtons;
    public Button PauseButton;
    public GameObject PauseButtons;
    public GameObject[] SoundButtons;
    public GameObject QuitUI;
    public GameObject SoundManager;

    void Start()
    {
        Time.timeScale = 1;
        GameOverUI.gameObject.SetActive(false);
        QuitUI.SetActive(false);

        if(PlayerPrefs.HasKey("BestScore") != false)
            BestScoreText.text = "" + PlayerPrefs.GetInt("BestScore");
            
        if(PlayerPrefs.GetInt("IsSoundOn") == 1){//Sound On
            PressSoundOffButton();
        }
        else if (PlayerPrefs.GetInt("IsSoundOn") == 0){//SoundOff
            PressSoundOnButton();
        }
    }

    void Update()
    {
        if (GameManager.instance.isPlayerDead == true)
        {
            GameUICanvas.gameObject.SetActive(false);
            
            GameOverTexts[0].text = "BEST\n" + PlayerPrefs.GetInt("BestScore");
            GameOverTexts[1].text = "SCORE\n" + GameManager.instance.playerScore;
            GameOverUI.gameObject.SetActive(true);
            
        }
        playerScoreText.text = "" + GameManager.instance.playerScore;

        if(Input.GetKeyDown(KeyCode.Escape)){
            Time.timeScale = 0;
            //Pause();
            QuitUI.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlayScene");
    }

    public void Pause(){
        if(Time.timeScale == 1){
            PauseButton.gameObject.SetActive(false);
            PauseButtons.SetActive(true);
            Time.timeScale = 0;
        }
            
        else if(Time.timeScale == 0){
            PauseButton.gameObject.SetActive(true);
            PauseButtons.SetActive(false);
            Time.timeScale = 1;
        }
            
    }

    public void ReturnToMain(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }
    public void PressSoundOffButton(){//        
        SoundButtons[1].SetActive(false);
        SoundButtons[0].SetActive(true);    
        PlayerPrefs.SetInt("IsSoundOn", 0);
        SoundManager.GetComponent<SoundManager>().OnSound();   
    }
    public void PressSoundOnButton(){        
        SoundButtons[0].SetActive(false);
        SoundButtons[1].SetActive(true);     
        PlayerPrefs.SetInt("IsSoundOn", 1);   
        SoundManager.GetComponent<SoundManager>().OffSound();   
    }
     public void QuitYes(){
        Application.Quit();
    }
    public void QuitNo(){
        Time.timeScale = 1;
        if(GameManager.instance.isPlayerDead != true)
            Pause();
        QuitUI.SetActive(false);
    }
}
