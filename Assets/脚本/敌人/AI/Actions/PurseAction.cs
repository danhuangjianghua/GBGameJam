using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurseAction : Action
{
    Enemy enemy;
    PurseBehavior behavior;
    BaseBehavior baseBehavior;

    public PurseAction(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public override void Init()
    {
        behavior = (PurseBehavior)enemy.behaviorDic[EnemyDataType.PurseData];
        baseBehavior = (BaseBehavior)enemy.behaviorDic[EnemyDataType.BaseData];
    }

    public override bool Evaluate()
    {
        Debug.Log(behavior.isPursing + " " + behavior.findTarget);
        return (behavior.isPursing || behavior.findTarget)&&!baseBehavior.isDizzy;
    }

    public override NodeState Process()
    {
        Debug.Log("×·Öðing");
        behavior.Purse();
        return NodeState.RUNNING;
    }
}
