using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType { 
    ButtonClick,
    PlayerMove,
    PlayerDeath,
    EnemyMove,
    EnemyDeath,
    Music
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    public GameSound[] Sounds;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic(SoundType.Music);
    }
    public void PlayMusic(SoundType soundType)
    {
        AudioClip clip = GetSoundClip(soundType);
        if (clip)
        {
            soundMusic.clip = clip;
            soundMusic.Play();
        }
        else
        {
            Debug.LogError("Sound not found : " + soundType.ToString());
        }
    }
    public void Play(SoundType soundType)
    {
        AudioClip clip = GetSoundClip(soundType);
        if (clip)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Sound not found : " + soundType.ToString());
        }
    }

    private AudioClip GetSoundClip(SoundType soundType)
    {
        GameSound sound = Array.Find(Sounds, x => x.soundType == soundType);
        if (sound != null)
            return sound.soundClip;
        return null;
    }
}
[Serializable]
public class GameSound {
    public SoundType soundType;
    public AudioClip soundClip;

}