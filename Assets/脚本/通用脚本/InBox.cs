using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InBox : MonoBehaviour
{
    Enemy enemy;
    public AudioSource pickupSource;
    public AudioSource eatFood;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Wood"|| collision.tag == "Stone"|| collision.tag == "FlexBox")
        {
            if(collision.tag == "Wood")
            {
                PlayerPrefs.SetInt("WhatCanEat", 0);
                PlayerPrefs.SetInt("CanEat", 0);//可吐
            }
            else if(collision.tag == "Stone")
            {
                PlayerPrefs.SetInt("WhatCanEat", 1);//0木块 1石块 2弹性盒子
                PlayerPrefs.SetInt("CanEat", 0);//可吐
            }
            else if(collision.tag == "FlexBox")
            {
                PlayerPrefs.SetInt("WhatCanEat", 2);//0木块 1石块 2弹性盒子
                PlayerPrefs.SetInt("CanEat", 0);//可吐
            }
            AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
            Destroy(collision.gameObject);
        }
        else if(collision.tag =="Item")
        {
            AudioSource.PlayClipAtPoint(eatFood.clip, gameObject.transform.position, pickupSource.volume);
            Destroy(collision.gameObject);
            int Grade = PlayerPrefs.GetInt("Grade") + 150;
            PlayerPrefs.SetInt("Grade", Grade);
        }
        else if (collision.tag == "Enemy")
        {
            enemy = collision.GetComponent<Enemy>();
            if (enemy.canBeEaten())
            {
            Destroy(collision.gameObject);
            int Grade = PlayerPrefs.GetInt("Grade") + 150;
            PlayerPrefs.SetInt("Grade", Grade);   
            }
        }
        else
        {
            Debug.Log("Dont eat anything");
        }
    }
}
