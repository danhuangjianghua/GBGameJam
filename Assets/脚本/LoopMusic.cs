using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopMusic : MonoBehaviour
{
    public AudioSource audio;
    public void Check(string sceneName)
    {
        if (sceneName != "Leve1" && sceneName != "Leve2" && sceneName != "Leve3")
        {
            audio.Stop();
        }
        else if(!audio.isPlaying) audio.Play();
    }
}
