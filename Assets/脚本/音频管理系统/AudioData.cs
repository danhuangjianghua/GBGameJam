using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName ="AudioData",menuName ="Config/AudioConfig")]
public class AudioData:ScriptableObject 
{
    [Header("音频片段")]
    public AudioClip clip;
    [Header("音量大小")]
    [Range(0, 1)] public float volume=1;
    [Header("音频分组")]
    public AudioMixerGroup group;
    [Header("是否物体激活即播放")]
    public bool playOnAwake;
    [Header("是否循环")]
    public bool loop;
}
