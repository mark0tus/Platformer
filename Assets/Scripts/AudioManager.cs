using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioMixerGroup audioMixerGroup;

    private AudioSource source;
    public string clipName;
    public AudioClip clip;

    public float volume;
    public float pitch;

    public bool loop = false;
    public bool playOnAwake = false;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.pitch = pitch;
        source.volume = volume;
        source.playOnAwake = playOnAwake;
        source.loop = loop;
    }

    public void Play()
    {
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    Sound[] sound;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        for (int i = 0; i < sound.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sound[i].clipName);
            _go.transform.SetParent(this.transform);
            sound[i].SetSource(_go.AddComponent<AudioSource>());
        }

        PlaySound("BGAmbient");
    }

    public void PlaySound(string _name)
    {
        for (int i = 0; i < sound.Length; i++)
        {
            if(sound[i].clipName == _name)
            {
                sound[i].Play();
                return;
            }
        }
    }
}
