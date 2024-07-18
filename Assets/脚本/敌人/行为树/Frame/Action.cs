using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : BTNode
{
    public ActionState actionState = ActionState.READY;

    public virtual void Enter()
    {
        actionState = ActionState.RUNNING;
    }

    public virtual void Stay()
    {

    }

    public virtual void Exit()
    {
        actionState = ActionState.READY;
    }

    public enum ActionState
    {
        READY,
        RUNNING
    }
}
