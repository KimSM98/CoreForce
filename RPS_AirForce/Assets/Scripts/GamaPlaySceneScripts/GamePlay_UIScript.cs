using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay_UIScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text playerScoreText;
    public Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        gameOverUI.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlayerDead == true)//GameOver상황
        {
            gameOverUI.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        playerScoreText.text = "Score: " + GameManager.instance.playerScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}
