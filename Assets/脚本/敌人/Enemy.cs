using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("µ–»Àπ¶ƒ‹≈‰÷√")]
    public List<EnemyData> configDatas = new List<EnemyData>();
    public Dictionary<EnemyDataType, EnemyData> dataDic = new Dictionary<EnemyDataType, EnemyData>();
    public Dictionary<EnemyDataType, EnemyBehavior> behaviorDic = new Dictionary<EnemyDataType, EnemyBehavior>();

    //ºÏ≤‚…œ±ﬂ
    public RaycastHit2D up;
    //ºÏ≤‚œ¬±ﬂ
    public RaycastHit2D down;
    //ºÏ≤‚◊Û±ﬂ
    public RaycastHit2D left;
    //ºÏ≤‚”“±ﬂ
    public RaycastHit2D right;

    //µ±«∞≥ØœÚ
    public Vector3 direction;
    public Direction directionState=Direction.UP;
    [HideInInspector]
    public Rigidbody2D rigi;
    public Animator animator;


    public bool canBeHit = true;


    private void Start()
    {
        
    }

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Init();
    }

    private void FixedUpdate()
    {
        float distance = ((BaseData)dataDic[EnemyDataType.BaseData]).distance;
        up = Physics2D.Raycast(transform.position,Vector2.up,distance,(1<<3)|(1<<7)|(1<<9));
        down = Physics2D.Raycast(transform.position, Vector2.down, distance, (1 << 3) | (1 << 7) | (1 << 9));
        left = Physics2D.Raycast(transform.position, Vector2.left, distance, (1 << 3) | (1 << 7) | (1 << 9));
        right = Physics2D.Raycast(transform.position, Vector2.right, distance, (1 << 3) | (1 << 7)| (1 << 9));
        if (up.collider != null) Debug.Log(up.collider.name);
        if (right.collider != null) Debug.Log(right.collider.name);
    }

    void Init()
    {
        foreach(var item in configDatas)
        {
            dataDic.Add(item.type, item);
            EnemyBehavior temp = null;
            item.returnType(ref temp,gameObject);
            temp.bindEnemy(this);
            behaviorDic.Add(item.type, temp);
        
        }
        configDatas.Clear();
    }

    public bool canBeEaten()
    {
        if(((BaseBehavior)behaviorDic[EnemyDataType.BaseData]).isDizzy)
        {
            ((BaseBehavior)behaviorDic[EnemyDataType.BaseData]).Die();
            return true;
        }
        return false;
    }
}
