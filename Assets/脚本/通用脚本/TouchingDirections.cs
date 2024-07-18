using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    //ContactFilter2D 是 Unity 中用于过滤 2D 物理接触的结构体。
    //它用于定义在执行物理操作（如射线投射、碰撞检测等）时应该考虑的条件和过滤选项


    private float groundDistance = 0.15f;
    private float wallDistance = 0.2f;
    private float ceilingDistance = 0.05f;
    //射线的最大投射距离：一个浮点数，表示射线的最大投射距离。

    BoxCollider2D touchingcol; //capsule(胶囊) 胶囊碰撞器

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    Animator animator;
    [SerializeField]
    private bool _isGrounded;
    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        private set
        {
            _isGrounded = value;
            animator.SetBool(AnimationString.isGrounded, value);
        }
    }

    //建了一个名为 groundHits 的数组，它可以存储最多 5 个 RaycastHit2D 结构体的实例。
    //RaycastHit2D 结构体通常用于存储射线投射的结果，包括被射线击中的物体的信息，如碰撞点、碰撞法线等。

    //RaycastHit2D 主要用于执行射线投射并获取碰撞信息。
    //你可以使用 Unity 提供的射线投射函数，如 Physics2D.Raycast，来发射一条射线，并将碰撞信息存储在 RaycastHit2D 结构体中。
    //然后，你可以检查碰撞点、法线、距离等属性，以便根据需要执行相应的操作，如物体移动、触发事件等。


    [SerializeField]
    private bool _isOnWall;
    public bool IsOnWall
    {
        get
        {
            return _isOnWall;
        }
        private set
        {
            _isOnWall = value;
            animator.SetBool(AnimationString.isOnWall, value);
        }
    }

    [SerializeField]
    private bool _isOnCeiling;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;//Vector2.right这个向量的值是 (1, 0)   Vector2.left这个向量的值是 (-1, 0)
    //通过方向赋值向量
    public bool IsOnCeiling
    {
        get
        {
            return _isOnCeiling;
        }
        private set
        {
            _isOnCeiling = value;
            animator.SetBool(AnimationString.isOnCeiling, value);
        }
    }

    private void Awake()
    {
        touchingcol = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        IsGrounded = touchingcol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;//Vector2.down（0，-1）
        IsOnWall = touchingcol.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingcol.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;//Vector2.up（0，1）
        //touchingcol.Cast 是一个方法调用，它用于执行 2D 射线投射，检测是否有物体与指定的射线相交
        //射线的方向：通常是一个 Vector2，表示射线的方向向量，例如 Vector2.down 表示向下发射。
        //射线的过滤条件：通常是一个 ContactFilter2D，用于定义哪些物体可以被射线检测到，可以包括层级、碰撞掩码等信息。
        //射线投射的结果：通常是一个 RaycastHit2D 数组，用于存储射线与物体相交的信息。
        //射线的最大投射距离：一个浮点数，表示射线的最大投射距离。
    }
    //游戏中判断角色是否靠近墙壁、地板、天花板，并根据需要执行相应的操作，例如阻止角色继续向墙壁或天花板移动。这对于平台游戏和角色控制非常有用。
}
