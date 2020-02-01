using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource MusicaDeFondo;
    public AudioSource efectos;
    public AudioSource efectos2;

    public GameObject efectoExtra;



    public AudioClip[] audioClips;
    public AudioClip[] backgroundClips;



    // Start is called before the first frame update
    void Start()
    {
        SoundController.AddSoundManager(this);
        StartCoroutine(ReproductorAleatoreo());
    }

    IEnumerator ReproductorAleatoreo()
    {


        while (true)
        {
            yield return new WaitForSeconds(2f);
            SoundController.PlayOtherSoundEfect(Random.Range(0, audioClips.Length));
        }
    }

}
