using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : BTNode
{
    int activeIndex = 0;

    public override NodeState Process()
    {
        NodeState state;
        if (activeIndex >= children.Count) activeIndex = 0;
        while(activeIndex<children.Count)
        {
            if (!children[activeIndex].Evaluate()) return NodeState.FAILURE;
            state = children[activeIndex].Process();
            if (state == NodeState.FAILURE)
            {
                activeIndex = 0;
                return NodeState.FAILURE;
            }
            else if (state == NodeState.RUNNING) return NodeState.RUNNING;
            else activeIndex++;
        }
        return NodeState.SUCCESS;
    }
}
