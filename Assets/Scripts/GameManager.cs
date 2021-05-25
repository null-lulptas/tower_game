using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool GameEnded = false;
    public GameObject gameoverui;
    public GameObject gamewonui;
    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {
        if (GameEnded)
        {            
            return;
        }
        if (PlayerStats.lives <= 0)
        {
            soundManager.Instance.PlayGameOver();           
            EndGame();
        }
    }
    void EndGame()
    {
        GameEnded = true;
        gameoverui.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameWon()
    {
        GameEnded = true;
        gamewonui.SetActive(true);
    }
}
