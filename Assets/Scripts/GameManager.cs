using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool GameEnded = false;
    public AudioSource backgroundmusic;
    private float musicVolume = 1f;
    // Update is called once per frame
    void Start()
    {
        backgroundmusic = GetComponent<AudioSource>();
        backgroundmusic.Play();

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
        backgroundmusic.volume = musicVolume;
    }
    void EndGame()
    {
        GameEnded = true;
        Debug.Log("Game Over");
    }
    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
}
