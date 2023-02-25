using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager instance => _instance;

    public static bool hasIntance => _instance != null;

    private void Start()
    {
        instance.Play(SoundName.BGM);
    }

    public enum SoundName
    {
        BGM,
        Player1Attack,
        Player2Attack,
        EnemyAttack,
        EnemyDead,
        Player1Dead,
        Player2Dead
    }

    [SerializeField] private Sound[] _sounds;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Play(SoundName name)
    {
        Sound sound = GetSound(name);
        if (sound.audioSource == null)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.loop;
        }

        sound.audioSource.Play();
    }

    private Sound GetSound(SoundName name)
    {
        return Array.Find(_sounds, s => s.soundName == name);
    }
}