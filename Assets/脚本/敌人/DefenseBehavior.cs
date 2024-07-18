using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseBehavior : EnemyBehavior
{
    public bool isDefense=false;
    public bool canDefense = true;

    public void Defense()
    {
        isDefense = true;
        canDefense = false;
        enemy.canBeHit = false;
        if (enemy.directionState == Direction.LEFT) enemy.animator.Play("defenseLeft");
        else if (enemy.directionState == Direction.RIGHT) enemy.animator.Play("defenseRight");
        else if (enemy.directionState == Direction.UP) enemy.animator.Play("defenseDown");
        else if (enemy.directionState == Direction.DOWN) enemy.animator.Play("defenseDown");
        StartCoroutine("Defensing");
    }

    IEnumerator Defensing()
    {
        yield return new WaitForSeconds(((DefenseData)enemy.dataDic[EnemyDataType.DefenseData]).duration);
        isDefense = false;
        enemy.canBeHit = true;
        ((BaseBehavior)enemy.behaviorDic[EnemyDataType.BaseData]).moveLock = false;
        yield return new WaitForSeconds(((DefenseData)enemy.dataDic[EnemyDataType.DefenseData]).interval);
        canDefense = true;
        ((BaseBehavior)enemy.behaviorDic[EnemyDataType.BaseData]).moveLock = true;
    }
}
