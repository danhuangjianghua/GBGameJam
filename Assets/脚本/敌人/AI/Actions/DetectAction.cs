using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAction : Action
{
    Enemy enemy;
    PurseBehavior behavior;
    BaseBehavior baseBehavior;

    public DetectAction(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public override bool Evaluate()
    {
        return !baseBehavior.isDizzy;
    }

    public override void Init()
    {
        behavior = (PurseBehavior)enemy.behaviorDic[EnemyDataType.PurseData];
        baseBehavior = (BaseBehavior)enemy.behaviorDic[EnemyDataType.BaseData];
    }

    public override NodeState Process()
    {
        Debug.Log("¹Û²ìing");
        behavior.Dectect();
        return NodeState.RUNNING;
    }
}
