using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAction : Action
{
    Transform pointA;
    Transform pointB;
    Enemy enemy;

    public override void Init()
    {
        
    }

    public override NodeState Process()
    {
        return NodeState.SUCCESS;
    }
}
