using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutBox : MonoBehaviour
{//�ƻ���Ƕ�붯����
    Animator animator;
    public GameObject[] projectilePrefab;
    public Vector2 Direction;
    public Transform[] launchPoint;//launchPoint �ƺ���һ�� Transform ���͵ı������������ڴ洢һ���ض���λ�ú���ת��Ϣ��
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
            // ������ִ�����ض�����״̬��صĲ���
            i = 0;
            PlayerPrefs.SetInt("Where", 0);//0�� 1�� 2����
        }
        else if(stateInfo.IsName("s_run")|| stateInfo.IsName("s_Idle"))
        {
            i = 1;
            PlayerPrefs.SetInt("Where", 1);//0�� 1�� 2����
        }
        else if (stateInfo.IsName("ad_run") || stateInfo.IsName("ad_Idle"))
        {
            PlayerPrefs.SetInt("Where", 2);//0�� 1�� 2����
            i = 2;
        }
        else
        {
            Debug.Log("not found ����״̬");
        }
        
    }

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab[PlayerPrefs.GetInt("WhatCanEat")], launchPoint[i].transform.position, transform.rotation);//Instantiate ����һ����������Ҫʵ������Ԥ�������projectilePrefab����Ȼ�������ڳ����д�����Ԥ�����һ����¡������һ���������¡��������á�
                                                                                                 //ͨ������£���Ὣ������ô洢��һ�������У��Ա���������������в�����
                                                                                                 //transform.rotation: ��ʵ��������ĳ�ʼ��ת�Ƕȣ�ͨ��ʹ�õ�ǰ�������ת��Ϣ��
        Vector3 origScale = projectile.transform.localScale;

        projectile.transform.localScale = new Vector3(
            origScale.x * transform.localScale.x > 0 ? origScale.x : -origScale.x,
            origScale.y,
            origScale.z
            );
       
        
        
    }
}