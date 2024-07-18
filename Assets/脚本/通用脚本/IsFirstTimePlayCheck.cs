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
        //HasKey�ش�boolֵ���ҵ��ش�true���Ҳ����ش�false
        if (!PlayerPrefs.HasKey("IsFirstTimePlayCheck"))//���ڼ���Ƿ����ĳ���ض�����key����PlayerPrefs�С�PlayerPrefs��һ���򵥵ı��ش洢ϵͳ��ͨ�����ڴ洢�ͼ�����Ϸ�����á����ƫ�����á��÷֡������Ĺؿ�����Ϣ��
        {
            PlayerPrefs.SetInt("IsFirstTimePlayCheck", 1);

            PlayerPrefs.SetInt("CanEat", 1);//�Ƿ���Գ�  1�ɳ�  0���³�
            PlayerPrefs.SetInt("WhatCanEat",0);//0ľ�� 1ʯ�� 2���Ժ���
            PlayerPrefs.SetInt("Where", 1);//0�� 1���� 2��
            PlayerPrefs.SetInt("Grade", 0);

        }
        //���������Ϸ�м���ʹ�ñ�������ݷǳ����ã���������ʾ��ҵ���߷���������Ĺؿ�ʱ��ע�⣬PlayerPrefs �洢������ͨ���Ǽ򵥵ļ�ֵ�ԣ������������ڴ洢�ͼ�����������Ϸ���ݡ�
    }


}
