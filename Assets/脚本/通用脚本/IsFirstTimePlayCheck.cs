using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFirstTimePlayCheck : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        FirstTimePlayState();
    }

    public void FirstTimePlayState()
    {
        //HasKey回传bool值，找到回传true，找不到回传false
        if (!PlayerPrefs.HasKey("IsFirstTimePlayCheck"))//用于检查是否存在某个特定键（key）在PlayerPrefs中。PlayerPrefs是一个简单的本地存储系统，通常用于存储和检索游戏的配置、玩家偏好设置、得分、解锁的关卡等信息。
        {
            PlayerPrefs.SetInt("IsFirstTimePlayCheck", 1);

            PlayerPrefs.SetInt("CanEat", 1);//是否可以吃  1可吃  0可吐出
            PlayerPrefs.SetInt("WhatCanEat",0);//0木块 1石块 2弹性盒子
            PlayerPrefs.SetInt("Where", 1);//0上 1左右 2下
            PlayerPrefs.SetInt("Grade", 0);

        }
        //这对于在游戏中检查和使用保存的数据非常有用，例如在显示玩家的最高分数或解锁的关卡时。注意，PlayerPrefs 存储的数据通常是简单的键值对，所以它适用于存储和检索基本的游戏数据。
    }


}
