using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int lives;
    public int startLives;

    private void Start()
    {
        lives = startLives;
    }
}
