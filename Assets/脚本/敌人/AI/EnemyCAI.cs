using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCAI : BTTree
{
    Enemy enemy;

    public override void Init()
    {
        root = new Selector();
        base.Init();
        enemy = GetComponent<Enemy>();
        DizzyAction dizzy = new DizzyAction(enemy);
        Parallel parallel = new Parallel();
        DetectAction detect = new DetectAction(enemy);
        PurseAction purse = new PurseAction(enemy);
        WalkAction walk = new WalkAction(enemy);
        Parallel parallel1 = new Parallel();
        root.AddChild(dizzy);
        parallel1.AddChild(detect);
        parallel1.AddChild(purse);
        parallel.AddChild(walk);
        parallel.AddChild(parallel1);
        root.AddChild(parallel);
    }
}
