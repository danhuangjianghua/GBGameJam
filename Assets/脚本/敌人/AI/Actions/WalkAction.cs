using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAction : Action
{
    Enemy enemy;
    BaseBehavior baseBehavior;

    public WalkAction(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public override bool Evaluate()
    {
        return !baseBehavior.moveLock&&!baseBehavior.isDizzy;
    }

    public override void Init()
    {
        baseBehavior = (BaseBehavior)enemy.behaviorDic[EnemyDataType.BaseData];
    }

    public override NodeState Process()
    {
        Debug.Log("ÒÆ¶¯ÖÐ");
        if (baseBehavior.isDizzy) return NodeState.FAILURE;
        baseBehavior.Move();
        if (baseBehavior.canMove) return NodeState.RUNNING;
        return NodeState.FAILURE;
    }
}
