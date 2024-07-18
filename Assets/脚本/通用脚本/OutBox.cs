using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBox : MonoBehaviour
{//计划是嵌入动画中
    Animator animator;
    public GameObject[] projectilePrefab;
    public Vector2 Direction;
    public Transform[] launchPoint;//launchPoint 似乎是一个 Transform 类型的变量，可能用于存储一个特定的位置和旋转信息。
    public int i;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("w_run")|| stateInfo.IsName("w_Idle"))
        {
            // 在这里执行与特定动画状态相关的操作
            i = 0;
            PlayerPrefs.SetInt("Where", 0);//0上 1下 2左右
        }
        else if(stateInfo.IsName("s_run")|| stateInfo.IsName("s_Idle"))
        {
            i = 1;
            PlayerPrefs.SetInt("Where", 1);//0上 1下 2左右
        }
        else if (stateInfo.IsName("ad_run") || stateInfo.IsName("ad_Idle"))
        {
            PlayerPrefs.SetInt("Where", 2);//0上 1下 2左右
            i = 2;
        }
        else
        {
            Debug.Log("not found 动画状态");
        }
        
    }

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab[PlayerPrefs.GetInt("WhatCanEat")], launchPoint[i].transform.position, transform.rotation);//Instantiate 接受一个参数，即要实例化的预制体对象（projectilePrefab），然后它会在场景中创建该预制体的一个克隆，返回一个对这个克隆对象的引用。
                                                                                                 //通常情况下，你会将这个引用存储在一个变量中，以便后续对这个对象进行操作。
                                                                                                 //transform.rotation: 新实例化对象的初始旋转角度，通常使用当前对象的旋转信息。
        Vector3 origScale = projectile.transform.localScale;

        projectile.transform.localScale = new Vector3(
            origScale.x * transform.localScale.x > 0 ? origScale.x : -origScale.x,
            origScale.y,
            origScale.z
            );
       
        
        
    }
}