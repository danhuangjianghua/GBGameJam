using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class DizzyAction : Action
{
    Enemy enemy;
    BaseBehavior baseBehavior;

    public DizzyAction(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public override void Init()
    {
        baseBehavior = (BaseBehavior)enemy.behaviorDic[EnemyDataType.BaseData];
    }

    public override bool Evaluate()
    {
        return baseBehavior.isDizzy;
    }

    public override void Enter()
    {
        baseBehavior.Dizzy();
        actionState = ActionState.RUNNING;
    }

    public override void Stay()
    {
        Debug.Log("—£‘Œ÷–" + baseBehavior.isDizzy);
    }

    public override NodeState Process()
    {
        if (actionState == ActionState.READY)
        {
            Enter();
            return NodeState.RUNNING;
        }
        if (actionState == ActionState.RUNNING)
        {
            Stay();
        }
        if (baseBehavior.isAwake)
        {
            Exit();
            baseBehavior.isDizzy = false;
            return NodeState.SUCCESS;
        }
        return NodeState.RUNNING;
    }
}
