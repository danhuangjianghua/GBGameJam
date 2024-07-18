using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWoodMove : MonoBehaviour
{
    public ContactFilter2D castFilter;
    public BoxCollider2D boxCollider2D;
    public int damage = 10;
    public Vector2 moveSpeed=new(3f,3f);
    public bool IsOnWall=false;
    private Vector2 wallCheckDirection;//检测方向
    Rigidbody2D rb;
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    public Vector2 knockBack = new Vector2(0, 0);
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        int i = PlayerPrefs.GetInt("Where");//0上 1左右 2下;
        if (i == 2)
        {
            rb.velocity = new Vector2(moveSpeed.x* transform.localScale.x, 0);
            wallCheckDirection = transform.localScale;
        }
        else if(i == 0)
        {
            rb.velocity = new Vector2(0f, 10f);
            wallCheckDirection = Vector2.up;
        }
        else if (i == 1)
        {
            rb.velocity = new Vector2(0f, -10f);
            wallCheckDirection = Vector2.down;
        }
        Block b;
        if(TryGetComponent<Block>(out b))
        {
            b.isMoving = true;
        }
    }

    public void stopMoving()
    {
        rb.velocity = new(0f, 0f);
    }
}
