using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    LevelView view;
    public Sprite wood;
    public Sprite stone;

    private void Awake()
    {
        view = GetComponent<LevelView>();
    }

    private void Update()
    {
        view.textGrade.text = PlayerPrefs.GetInt("Grade").ToString();
        if (PlayerPrefs.GetInt("CanEat") == 0)
        {
            switch (PlayerPrefs.GetInt("WhatCanEat"))
            {
                case 0:
                    view.imageHaveBlock.sprite = wood;
                    break;
                case 1:
                    view.imageHaveBlock.sprite = stone;
                    break;
                default:
                    break;
            }
        }
        else view.imageHaveBlock.sprite = null;
    }
}
