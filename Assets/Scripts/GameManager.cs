using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool GameEnded = false;
    public AudioSource backgroundmusic;
    // Update is called once per frame
    void Start()
    {
        backgroundmusic = GetComponent<AudioSource>();

    }
    void Update()
    {
        if (GameEnded)
        {
            backgroundmusic.Play();
            return;
        }
        if (PlayerStats.lives <= 0)
        {
            backgroundmusic.Stop();
            EndGame();
        }
    }
    void EndGame()
    {
        GameEnded = true;
        Debug.Log("Game Over");
    }
}
