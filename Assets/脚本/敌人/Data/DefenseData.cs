using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefenseData", menuName = "Config/EnemyData/DefenseData")]
public class DefenseData : EnemyData
{
    [Header("防御持续时间")]
    public float duration;
    [Header("防御冷却时间")]
    public float interval;

    public override void returnType(ref EnemyBehavior behaviour, GameObject g)
    {
        behaviour = g.AddComponent<DefenseBehavior>();
    }
}
