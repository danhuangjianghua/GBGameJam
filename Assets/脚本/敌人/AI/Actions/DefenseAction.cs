using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseAction : Action
{
    Enemy enemy;
    DefenseBehavior behavior;

    public DefenseAction(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public override void Init()
    {
        behavior = (DefenseBehavior)enemy.behaviorDic[EnemyDataType.DefenseData];
    }

    public override bool Evaluate()
    {
        //Debug.Log("∑¿”˘≈–∂œ"+ behavior.canDefense);
        return behavior.canDefense||behavior.isDefense;
    }

    public override void Enter()
    {
        behavior.Defense();
        actionState = ActionState.RUNNING;
    }

    public override void Stay()
    {
        //Debug.Log("∑¿”˘÷–");
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
        if (!behavior.isDefense)
        {
            Exit();
            return NodeState.SUCCESS;
        }
        return NodeState.RUNNING;
    }
}
