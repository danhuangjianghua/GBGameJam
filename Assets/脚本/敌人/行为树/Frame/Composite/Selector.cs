using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : BTNode
{
    BTNode activeChild = null;
    public override NodeState Process()
    {
        NodeState state;
        if(activeChild!=null&&activeChild.Evaluate())
        {
            state = activeChild.Process();
            if (state == NodeState.RUNNING) return state;
        }
        foreach(BTNode child in children)
        {
            if(child.Evaluate())
            {
                state = child.Process();
                if(state!=NodeState.FAILURE)
                {
                    if (child != activeChild) activeChild = child;
                    return state;
                }
            }
        }
        activeChild = null;
        return NodeState.FAILURE;
    }
}
