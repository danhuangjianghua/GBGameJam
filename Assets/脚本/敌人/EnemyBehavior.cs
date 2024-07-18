using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior:MonoBehaviour
{
    protected Enemy enemy;
    public void bindEnemy(Enemy e)
    {
        enemy = e;
    }
}
