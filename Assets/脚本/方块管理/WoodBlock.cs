using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WoodBlock : Block
{
    public AudioSource pickupSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Wood" || collision.gameObject.tag == "Stone")
        {
            AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
            Destroy(gameObject);
            return;
        }
        if (!isMoving) return;
        if(collision.gameObject.tag=="Player_Tun")
        {
            //玩家死亡函数调用
            AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
            collision.gameObject.GetComponent<PlayerControl>().Die();
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("撞到怪物");
            AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
            ((BaseBehavior)collision.gameObject.GetComponent<Enemy>().behaviorDic[EnemyDataType.BaseData]).beHit();
            StartCoroutine("beDestroy");
        }
        else if(collision.gameObject.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Wall"|| collision.gameObject.tag == "Item"|| collision.gameObject.tag == "Stone")
        {
            AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
            Destroy(gameObject);
        }
    }

    

    IEnumerator beDestroy()
    {

        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
}
