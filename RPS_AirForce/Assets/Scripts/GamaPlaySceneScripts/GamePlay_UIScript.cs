using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay_UIScript : MonoBehaviour
{
    //public GameObject gameOverUI;
    public Canvas GameUICanvas;
    public Text playerScoreText;
    public Text BestScoreText;
    public GameObject GameOverUI;
    public Text[] GameOverTexts;
    public GameObject AttackButtons;
    public Button PauseButton;
    public GameObject PauseButtons;
    public Button[] SoundButtons;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        //gameOverUI.SetActive(false);
        GameOverUI.gameObject.SetActive(false);
        
        if(PlayerPrefs.HasKey("BestScore") != false)
            BestScoreText.text = "" + PlayerPrefs.GetInt("BestScore");
            
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlayerDead == true)//GameOver상황
        {
            GameUICanvas.gameObject.SetActive(false);
            
            GameOverTexts[0].text = "BEST\n" + PlayerPrefs.GetInt("BestScore");
            GameOverTexts[1].text = "SCORE\n" + GameManager.instance.playerScore;
            GameOverUI.gameObject.SetActive(true);
            
        }
        playerScoreText.text = "" + GameManager.instance.playerScore;
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

    public void SoundOnOff(){
        
    }
}
