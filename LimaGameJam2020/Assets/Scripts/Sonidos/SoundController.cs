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
        soundManager.MusicaDeFondo.volume = volume;
        soundManager.MusicaDeFondo.Play();
    }

    public static void PlaSoundEfect(int _value)
    {
        if (_value >= soundManager.audioClips.Length) return;

        soundManager.efectos.clip = soundManager.audioClips[_value];
        soundManager.efectos.volume = volume;
        soundManager.efectos.Play();
    }
    public static void PlaSoundEfect2(int _value)
    {
        if (_value >= soundManager.audioClips.Length) return;

        soundManager.efectos2.clip = soundManager.audioClips[_value];
        soundManager.efectos2.volume = volume;
        soundManager.efectos2.Play();
    }

    public static void SetVolume(int _value)
    {
        volume = -_value;
    }


}
