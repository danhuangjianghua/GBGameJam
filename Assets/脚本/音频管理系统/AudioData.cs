using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName ="AudioData",menuName ="Config/AudioConfig")]
public class AudioData:ScriptableObject 
{
    [Header("��ƵƬ��")]
    public AudioClip clip;
    [Header("������С")]
    [Range(0, 1)] public float volume=1;
    [Header("��Ƶ����")]
    public AudioMixerGroup group;
    [Header("�Ƿ����弤�����")]
    public bool playOnAwake;
    [Header("�Ƿ�ѭ��")]
    public bool loop;
}
