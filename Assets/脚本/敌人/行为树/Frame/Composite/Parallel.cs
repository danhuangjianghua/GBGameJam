using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallel : BTNode
{   public override NodeState Process()
    {
        List<NodeState> states = new List<NodeState>();
        for (int i=0;i<children.Count;++i)
        {
            NodeState state;
            if (children[i].Evaluate())
            {
                state = children[i].Process();
                states.Add(state);
            }
            else states.Add(NodeState.FAILURE);
        }
        bool allSuccess = true;
        bool allFailure = true;
        for(int i=0;i<states.Count;++i)
        {
            if (states[i] == NodeState.SUCCESS) allFailure = false;
            else if (states[i] == NodeState.FAILURE) allSuccess = false;
            else return NodeState.RUNNING;
        }
        if (allSuccess) return NodeState.SUCCESS;
        if (allFailure) return NodeState.FAILURE;
        return NodeState.RUNNING;
    }
}
