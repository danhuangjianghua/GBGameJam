using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBlock : Block
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isMoving) return;
        if (collision.gameObject.tag == "Player_Tun")
        {
            //玩家死亡函数调用
            collision.gameObject.GetComponent<PlayerControl>().Die();
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            if(!((BaseBehavior)collision.gameObject.GetComponent<Enemy>().behaviorDic[EnemyDataType.BaseData]).beHit())
            {
                Destroy(GetComponent<ObjectWoodMove>());
                GetComponent<Rigidbody2D>().velocity = new(0f, 0f);
                GetComponent<Rigidbody2D>().mass = 1000;
                GetComponent<BoxCollider2D>().isTrigger = false;
                isMoving = false;
            }
        }
        else if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Stone"|| collision.gameObject.tag == "Item")
        {
            Destroy(GetComponent<ObjectWoodMove>());
            GetComponent<Rigidbody2D>().velocity = new(0f, 0f);
            GetComponent<Rigidbody2D>().mass = 1000;
            GetComponent<BoxCollider2D>().isTrigger = false;
            isMoving = false;
        }
    }
}
