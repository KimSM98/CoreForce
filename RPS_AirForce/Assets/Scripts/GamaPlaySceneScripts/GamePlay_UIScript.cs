using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay_UIScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text playerScoreText;
    public Text BestScoreText;
    public Button restartButton;
    public GameObject AttackButtons;
    public Button PauseButton;
    public GameObject PauseButtons;
    public Button[] SoundButtons;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOverUI.SetActive(false);
        restartButton.gameObject.SetActive(false);
        
        if(PlayerPrefs.HasKey("BestScore") != false)
            BestScoreText.text = "" + PlayerPrefs.GetInt("BestScore");
            
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlayerDead == true)//GameOver상황
        {
            gameOverUI.SetActive(true);
            restartButton.gameObject.SetActive(true);
            AttackButtons.SetActive(false);
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
