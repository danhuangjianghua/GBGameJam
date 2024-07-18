using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefenseData", menuName = "Config/EnemyData/DefenseData")]
public class DefenseData : EnemyData
{
    [Header("��������ʱ��")]
    public float duration;
    [Header("������ȴʱ��")]
    public float interval;

    public override void returnType(ref EnemyBehavior behaviour, GameObject g)
    {
        behaviour = g.AddComponent<DefenseBehavior>();
    }
}
