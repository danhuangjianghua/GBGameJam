using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public AudioSource loopSource;

    private void Start()
    {
        loopSource.Play();
    }
}
