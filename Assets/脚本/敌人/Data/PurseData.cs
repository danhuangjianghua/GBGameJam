using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PurseData", menuName = "Config/EnemyData/PurseData")]
public class PurseData : EnemyData
{
    [Header("��ⷶΧ")]
    public float radius;
    [Header("׷���ٶ�")]
    public float speed;

    public override void returnType(ref EnemyBehavior behaviour, GameObject g)
    {
        behaviour = g.AddComponent<PurseBehavior>();
    }
}
