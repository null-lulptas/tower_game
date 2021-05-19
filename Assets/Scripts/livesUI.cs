using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class livesUI : MonoBehaviour
{
    public Sprite[] sprites;
    public int fullHP;
    void Update()
    {
        Image image = gameObject.GetComponent<Image>();
        if (fullHP == PlayerStats.lives)
        {
            image.sprite = sprites[0];
        }
        else if (PlayerStats.lives <= fullHP * 0.9 
            && PlayerStats.lives >= fullHP * 0.5)
        {
            image.sprite = sprites[1];
        }
        else if (PlayerStats.lives < fullHP * 0.5
            && PlayerStats.lives >= fullHP * 0.25)
        {
            image.sprite = sprites[2];
        }
        else if (PlayerStats.lives < fullHP * 0.25
            && PlayerStats.lives != 0)
        {
            image.sprite = sprites[3];
        }
        else
        {
            image.sprite = sprites[4];
        }
    }
}
