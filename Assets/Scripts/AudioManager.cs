using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sound
{
    private AudioSource audioSource;
    public string clipName;
    public AudioClip audioClip;

    [Range(0, 1f)]
    public float volume;
    [Range(-3f, 3f)]
    public float pitch;

    public bool playOnAwake = false;
    public bool loop = false;

    public void SetSource(AudioSource source)
    {
        audioSource = source;
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.playOnAwake = playOnAwake;
        audioSource.loop = loop;
    }

    public void Play()
    {
        audioSource.Play();
    }

    public void Mute()
    {
        audioSource.mute = !audioSource.mute;
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;


    [SerializeField]
    Sound[] sounds;

    public Sprite onSound, offSound;

    public bool isMute = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(this.gameObject);

        
    }

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject go = new GameObject("Sound " + sounds[i].clipName);
            go.transform.SetParent(this.transform);
            sounds[i].SetSource(go.AddComponent<AudioSource>());
        }

        PlaySound("theme");

    }

    public void PlaySound(string name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].clipName == name)
            {
                sounds[i].Play();
            }
        }
    }

    public void MuteSound()
    {
        foreach (var sound in sounds)
        {
            sound.Mute();
        }
    }
}
