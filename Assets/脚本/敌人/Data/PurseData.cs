using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PurseData", menuName = "Config/EnemyData/PurseData")]
public class PurseData : EnemyData
{
    [Header("¼ì²â·¶Î§")]
    public float radius;
    [Header("×·»÷ËÙ¶È")]
    public float speed;

    public override void returnType(ref EnemyBehavior behaviour, GameObject g)
    {
        behaviour = g.AddComponent<PurseBehavior>();
    }
}
