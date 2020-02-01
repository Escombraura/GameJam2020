using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource MusicaDeFondo;
    public AudioSource efectos;
    public AudioSource efectos2;



    public AudioClip[] audioClips;


    // Start is called before the first frame update
    void Start()
    {
        SoundController.AddSoundManager(this);
    }

}
