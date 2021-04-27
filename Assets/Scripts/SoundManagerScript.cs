using UnityEngine.Audio;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{   
    public static AudioClip BulletImpact;
    public static AudioSource audioSource;
    public static  bool alreadyplayed = false;
    // Start is called before the first frame update
    void Start()
    {
        BulletImpact = Resources.Load<AudioClip>("BulletImpact");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.loop = true;
    }
    public static void PlaySound(string clip)
    {
        if (!alreadyplayed)
        {
            switch (clip)
            {
                case "BulletImpactSound":
                    audioSource.PlayOneShot(BulletImpact, 0.7F);
                    alreadyplayed = false;
                    break;
            }
        }
    }
}
