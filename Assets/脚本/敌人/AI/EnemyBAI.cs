using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBAI : BTTree
{
    Enemy enemy;

    public override void Init()
    {
        root = new Selector();
        base.Init();
        enemy = GetComponent<Enemy>();
        DefenseAction defense = new DefenseAction(enemy);
        DizzyAction dizzy = new DizzyAction(enemy);
        WalkAction walk = new WalkAction(enemy);
        root.AddChild(defense);
        root.AddChild(dizzy);
        root.AddChild(walk);
    }
}
