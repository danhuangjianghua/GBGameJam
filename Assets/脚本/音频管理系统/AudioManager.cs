using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private static AudioManager manager;
    public static AudioManager audioManager
    {
        get
        {
            return manager;
        }
    }

    AudioManager()
    {
        if(manager==null) manager = this;
    }

    [Header("“Ù∆µ≈‰÷√")]
    [SerializeField]
    List<AudioData> audioDatas = new List<AudioData>();
    Dictionary<string, AudioSource> dic = new Dictionary<string, AudioSource>();

    [Header("“Ù∆µªÏœÏ")]
    [SerializeField]
    AudioMixer mixer;

    public GameObject setting;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        foreach(var item in audioDatas)
        {
            GameObject g = new GameObject(item.clip.name);
            g.transform.SetParent(transform);
            AudioSource a=g.AddComponent<AudioSource>();
            a.clip = item.clip;
            a.volume = item.volume;
            a.outputAudioMixerGroup = item.group;
            a.playOnAwake = item.playOnAwake;
            a.loop = item.loop;
            dic.Add(item.clip.name, a);
        }
    }
    
    public void playAudio(string clipName)
    {
        if (dic.ContainsKey(clipName))
        {
            dic[clipName].Play();
            return;
        }
        Debug.LogWarning("“Ù∆µ≤ª¥Ê‘⁄");
    }

    public void stopAudio(string clipName)
    {
        if (dic.ContainsKey(clipName))
        {
            dic[clipName].Stop();
            return;
        }
        Debug.LogWarning("“Ù∆µ≤ª¥Ê‘⁄");
    }

    public void adjustMusicVolume(float value)
    {
        mixer.SetFloat("MUSIC", value);
    }

    public void adjustSoundVolume(float value)
    {
        mixer.SetFloat("SOUND", value);
    }

    public void openAudioSetting()
    {
        setting.SetActive(true);
    }

    public void closeAudioSetting()
    {
        gameObject.SetActive(false);
    }
}
