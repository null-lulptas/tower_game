using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class soundManager : Singleton<soundManager>
{

    public AudioSource music;
    public Slider musicSlider;
    public AudioSource over;
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        musicSlider.value = music.volume;
        over.volume = musicSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume(float volume)
    {        
        mixer.SetFloat("volume",volume);
        PlayerPrefs.SetFloat("volume", volume);
    }

    public void PlayGameOver()
    {
        music.Stop();
        over.Play();
    }
}
