using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int lives;
    public int startLives;

    public static int score;
    public int startScore;

    public static int money;
    public int startMoney;

    private void Start()
    {
        lives = startLives;
        score = startScore;
        money = startMoney;
    }
}
