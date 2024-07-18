using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DizzyTest : MonoBehaviour
{
    public Tilemap t;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //((BaseBehavior)collision.gameObject.GetComponent<Enemy>().behaviorDic[EnemyDataType.BaseData]).beHit(t.CellToWorld(t.WorldToCell(transform.position)));
        Destroy(gameObject);
    }
}
