using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        string levelToLoad = "LevelSelect";
        SceneManager.LoadScene(levelToLoad);
    }
    public void Options()
    {
        string levelToLoad = "Options";
        SceneManager.LoadScene(levelToLoad);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
