using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BaseData",menuName ="Config/EnemyData/BaseData")]
public class BaseData : EnemyData
{
    [Header("移动速度")]
    public float speed;
    [Header("眩晕持续时间")]
    public float duration;
    [Header("检测范围")]
    public float distance;


    public  override void returnType(ref EnemyBehavior behaviour,GameObject g)
    {
        behaviour = g.AddComponent<BaseBehavior>();
    }
}
