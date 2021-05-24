using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundManager : Singleton<soundManager>
{

    public AudioSource music;

    public Slider musicSlider;

    public AudioSource over;
    // Start is called before the first frame update
    void Start()
    {
        LoadVolume();
        musicSlider.value = music.volume;
        over.volume = musicSlider.value; ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateVolume()
    {
        music.volume = musicSlider.value;
        over.volume = musicSlider.value; ;

        PlayerPrefs.SetFloat("MUSIC", musicSlider.value);        
    }

    public void LoadVolume()
    {
        music.volume = PlayerPrefs.GetFloat("MUSIC", 1f);
    }

    public void PlayGameOver()
    {
        music.Stop();
        over.Play();
    }
}
