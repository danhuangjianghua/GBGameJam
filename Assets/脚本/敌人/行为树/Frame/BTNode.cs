using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTNode
{
    public List<PreCondition> preConditions = new List<PreCondition>();
    public List<BTNode> children = new List<BTNode>();
    public DataBase db;

    public virtual bool Evaluate()
    {
        foreach(PreCondition item in preConditions)
        {
            if (item.Check() == false) return false;
        }
        return true;
    }

    public void AddPreCondition(PreCondition condition)
    {
        preConditions.Add(condition);
    }

    public void AddChild(BTNode node)
    {
        children.Add(node);
        node.Activate(db);
    }

    public void Activate(DataBase db)
    {
        this.db = db;
        Init();
    }

    public virtual NodeState Process()
    {
        return NodeState.SUCCESS;
    }

    public virtual void Init()
    {

    }
}
