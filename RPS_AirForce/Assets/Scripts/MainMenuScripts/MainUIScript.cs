using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIScript : MonoBehaviour
{
    public void GameStartButton()
    {
        SceneManager.LoadScene("GamePlayScene");
    }
}
