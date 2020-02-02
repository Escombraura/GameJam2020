using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundController
{
    public static SoundManager soundManager;
    public static int volume;

    public static void AddSoundManager(SoundManager _soundManager)
    {
        soundManager = _soundManager;
        volume = 1;
        //Eliminar para no reproducir al inicio automaticamente
        PlayBackGroundMusic();
    }

    public static void PlayBackGroundMusic()
    {
        soundManager.MusicaDeFondo.clip = soundManager.backgroundClips[1];
        soundManager.MusicaDeFondo.volume = 0.9f;
        soundManager.MusicaDeFondo.Play();
    }

    public static void PlaSoundEfect(int _value)
    {
        if (_value >= soundManager.audioClips.Length) return;

        soundManager.efectos.clip = soundManager.audioClips[_value];
        soundManager.efectos.volume = volume;
        soundManager.efectos.Play();
    }
    public static void PlaySoundEfectLoop(int _value)
    {
        if (_value >= soundManager.audioClips.Length) return;
        soundManager.efectos2.clip = soundManager.audioClips[_value];
        soundManager.efectos2.volume = volume;
        soundManager.efectos2.Play();
    }

    public static void StopSoundEfectLoop()
    {
        soundManager.efectos2.Stop();
    }

    public static void SetVolume(int _value)
    {
        volume = -_value;
    }

    public static void PlayOtherSoundEfect(int _value)
    {
        GameObject _objeto = Object.Instantiate(soundManager.efectoExtra);
        _objeto.transform.SetParent(soundManager.gameObject.transform);
        AudioSource _miAudio = _objeto.GetComponent<AudioSource>();

        if (_value >= soundManager.audioClips.Length) return;

        _miAudio.clip = soundManager.audioClips[_value];
        _miAudio.volume = volume;
        _miAudio.Play();
    }

    public static void PlayOtherSoundEfect(int _value, float _pitchValue)
    {
        GameObject _objeto = Object.Instantiate(soundManager.efectoExtra);
        _objeto.transform.SetParent(soundManager.gameObject.transform);
        AudioSource _miAudio = _objeto.GetComponent<AudioSource>();

        if (_value >= soundManager.audioClips.Length) return;
        _miAudio.pitch = _pitchValue;
        _miAudio.clip = soundManager.audioClips[_value];
        _miAudio.volume = volume;
        _miAudio.Play();
    }
}



