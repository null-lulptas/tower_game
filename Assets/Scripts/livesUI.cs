using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesUI : MonoBehaviour
{
    public Text livesText;


    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.lives <= 0)
        {
            livesText.text = 0 + " LIVES";
        }
        else
        {
            livesText.text = PlayerStats.lives + " LIVES";
        }
    }
}
