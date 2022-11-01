using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    public static AudioManager current;

    [Header("环境声音")]
    public AudioClip ambientClip;
    public AudioClip musicClip;

    [Header("Player音效")]
    public AudioClip[] walkStepClips;
    public AudioClip trueClip;
    public AudioClip falseClip;
    public AudioClip defeatClip;

    [Header("Voice")]
    public AudioClip moveVoice;
    public AudioClip[] dashVoice;
    public AudioClip[] attackVoice;

    AudioSource ambientSource;
    public AudioSource musicSource;
    AudioSource fxSorce;
    AudioSource playerSource;
    AudioSource voiceSource;
    protected override void Awake()
    {
        current = this;

        DontDestroyOnLoad(gameObject);

        ambientSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        fxSorce = gameObject.AddComponent<AudioSource>();
        playerSource = gameObject.AddComponent<AudioSource>();
        voiceSource = gameObject.AddComponent<AudioSource>();

        current.StartMusic();
    }

    void Start()
    {
        
    }

    public static void PlayerMoveAudio()
    {
        current.voiceSource.clip = current.moveVoice;
        current.voiceSource.Play();
    }

    public static void TrueAudio()
    {
        current.playerSource.clip = current.trueClip;
        current.playerSource.Play();
    }

    public static void FalseAudio()
    {
        current.playerSource.clip = current.falseClip;
        current.playerSource.Play();
    }

    public static void DefeatAudio()
    {
        current.playerSource.clip = current.defeatClip;
        current.playerSource.Play();
    }
    void StartMusic()
    {
        current.musicSource.clip = current.musicClip;
        current.musicSource.loop = true;
        current.musicSource.Play();
    }
}
