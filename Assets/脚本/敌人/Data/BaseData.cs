using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BaseData",menuName ="Config/EnemyData/BaseData")]
public class BaseData : EnemyData
{
    [Header("�ƶ��ٶ�")]
    public float speed;
    [Header("ѣ�γ���ʱ��")]
    public float duration;
    [Header("��ⷶΧ")]
    public float distance;


    public  override void returnType(ref EnemyBehavior behaviour,GameObject g)
    {
        behaviour = g.AddComponent<BaseBehavior>();
    }
}
