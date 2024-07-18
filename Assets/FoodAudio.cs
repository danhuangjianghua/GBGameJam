using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAudio : MonoBehaviour
{
    AudioSource pickupSource;
    private void Awake()
    {
        pickupSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (pickupSource != null)
       {
            AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
       }       
    }
}
