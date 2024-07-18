using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurseBehavior : EnemyBehavior
{
    public bool findTarget = false;
    public Transform target;
    AStarPathFinding pathFinding = new AStarPathFinding();
    List<Vector3Int> path = new List<Vector3Int>();
    public bool isMoving = false;
    public bool isPursing = false;

    public void Dectect()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(this.transform.position, ((PurseData)enemy.dataDic[EnemyDataType.PurseData]).radius, LayerMask.GetMask("Player"));
        //Debug.Log(hits.Length+" " + ((PurseData)enemy.dataDic[EnemyDataType.PurseData]).radius);
        if (hits.Length > 0&&!isMoving)
        {
            if (target == null)
            {
                target = hits[0].gameObject.transform;
                path.Clear();
                path = pathFinding.FindPath(TilemapManager.tilemapManager.worldToCell(transform.position), TilemapManager.tilemapManager.worldToCell(target.position));
                Debug.Log("Â·³¤"+path.Count);
            }
            else
            {
                Vector3Int v1 = TilemapManager.tilemapManager.worldToCell(target.position);
                Vector3Int v2 = TilemapManager.tilemapManager.worldToCell(hits[0].gameObject.transform.position);
                if (v1 != v2)
                {
                    path.Clear();
                    path = pathFinding.FindPath(TilemapManager.tilemapManager.worldToCell(transform.position), v2);
                }
                target = hits[0].gameObject.transform;
            }
            findTarget = true;
        }
        else if(hits.Length<=0)
        {
            findTarget = false;
            target = null;
        }
    }

    public void Purse()
    {
        isPursing = true;
        ((BaseBehavior)enemy.behaviorDic[EnemyDataType.BaseData]).moveLock = true;
        if (isMoving) return;
        isMoving = true;
        StartCoroutine("Pursing", TilemapManager.tilemapManager.cellToWorld(path[0]));
        path.RemoveAt(0);
        if (path.Count <= 0)
        {
            ((BaseBehavior)enemy.behaviorDic[EnemyDataType.BaseData]).moveLock = false;
            isPursing = false;
        }
    }

    IEnumerator Pursing(Vector3 v)
    {
        float time = 0;
        Vector3 startV = enemy.transform.position;
        v.Set(v.x + 0.5f, v.y + 0.5f, 0);
        float speed = ((PurseData)enemy.dataDic[EnemyDataType.PurseData]).speed;
        while (time < 1)
        {
            Vector3 temp = Vector3.Lerp(startV, v, time);
            //Debug.Log(temp);
            enemy.rigi.MovePosition(temp);
            time += (Time.deltaTime*speed);
            yield return null;
        }
        isMoving = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, ((PurseData)enemy.dataDic[EnemyDataType.PurseData]).radius);
    }
}
