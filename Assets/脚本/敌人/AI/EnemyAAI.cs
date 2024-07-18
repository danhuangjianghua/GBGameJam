using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAAI : BTTree
{
    Enemy enemy;

    public override void Init()
    {
        root = new Selector();
        base.Init();
        enemy = GetComponent<Enemy>();
        DizzyAction dizzy = new DizzyAction(enemy);
        WalkAction walk = new WalkAction(enemy);
        root.AddChild(dizzy);
        root.AddChild(walk);
    }
}
