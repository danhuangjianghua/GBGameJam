using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehavior:EnemyBehavior
{
    public bool isDizzy = false;
    public bool isAwake = true;
    public bool canMove = true;
    public bool moveLock = false;
    public Vector3 hitPos;
    public void Move()
    {
        Turn();
        if (enemy.up.collider == null || enemy.down.collider == null || enemy.left.collider == null || enemy.right.collider == null) canMove = true;
        else canMove=false;
        if (canMove)
        {
            if (enemy.directionState == Direction.UP) enemy.animator.Play("walkUp");
            else if (enemy.directionState == Direction.DOWN) enemy.animator.Play("walkDown");
            else if (enemy.directionState == Direction.LEFT) enemy.animator.Play("walkLeft");
            else if (enemy.directionState == Direction.RIGHT) enemy.animator.Play("walkRight");
            transform.Translate(enemy.direction * ((BaseData)enemy.dataDic[EnemyDataType.BaseData]).speed * Time.deltaTime);
        }
    }

    public bool beHit()
    {
        //Debug.Log("behit"+enemy.canBeHit);
        if (!enemy.canBeHit) return false;
        isDizzy = true;
        isAwake = false;
        return true;
    }

    public void Dizzy()
    {
        enemy.canBeHit = false;
        //Debug.Log("dddddd");
        enemy.animator.Play("Dizzy");
        //StartCoroutine("beAttracted", hitPos);
        StartCoroutine("Dizzying");
    }

    public void Die()
    {
        MsgManager.msgManager.sendMessage(MsgName.EnemyDie, this, null);
        Destroy(gameObject);
    }

    public void Turn()
    {
        switch(enemy.directionState)
        {
            case Direction.UP:
                if(enemy.up.collider!=null)
                {
                    if (enemy.down.collider == null) enemy.directionState = Direction.DOWN;
                    else if (enemy.left.collider == null) enemy.directionState = Direction.LEFT;
                    else if (enemy.right.collider == null) enemy.directionState = Direction.RIGHT;
                }
                break;
            case Direction.DOWN:
                if (enemy.down.collider != null)
                {
                    if (enemy.up.collider == null) enemy.directionState = Direction.UP;
                    else if (enemy.left.collider == null) enemy.directionState = Direction.LEFT;
                    else if (enemy.right.collider == null) enemy.directionState = Direction.RIGHT;
                }
                break;
            case Direction.LEFT:
                if (enemy.left.collider != null)
                {
                    if (enemy.right.collider == null) enemy.directionState = Direction.RIGHT;
                    else if (enemy.down.collider == null) enemy.directionState = Direction.DOWN;
                    else if (enemy.up.collider == null) enemy.directionState = Direction.UP;
                }
                break;
            case Direction.RIGHT:
                if (enemy.right.collider != null)
                {
                    if (enemy.left.collider == null) enemy.directionState = Direction.LEFT;
                    else if (enemy.down.collider == null) enemy.directionState = Direction.DOWN;
                    else if (enemy.up.collider == null) enemy.directionState = Direction.UP;
                }
                break;
        }
        changeDirection(enemy.directionState);
    }

    public void changeDirection(Direction d)
    {
        switch(d)
        {
            case Direction.UP:
                enemy.direction = Vector3.up;
                break;
            case Direction.DOWN:
                enemy.direction = Vector3.down;
                break;
            case Direction.LEFT:
                enemy.direction = Vector3.left;
                break;
            case Direction.RIGHT:
                enemy.direction = Vector3.right;
                break;
        }
    }

    IEnumerator beAttracted(Vector3 v)
    {
        //Debug.Log("吸引开始"+v);
        float time = 0;
        Vector3 startV = enemy.transform.position;
        v.Set(v.x + 0.5f, v.y + 0.5f, 0);
        while(time<1)
        {
            Vector3 temp = Vector3.Lerp(startV, v, time);
            enemy.rigi.MovePosition(temp);
            time += Time.deltaTime;
            yield return null;
        }
        //Debug.Log("吸引结束");
    }

    IEnumerator Dizzying()
    {
        yield return new WaitForSeconds(((BaseData)enemy.dataDic[EnemyDataType.BaseData]).duration);
        isAwake = true;
        enemy.canBeHit = true;
    }
}
