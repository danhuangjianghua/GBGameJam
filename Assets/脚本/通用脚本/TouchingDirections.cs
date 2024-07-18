using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;
    //ContactFilter2D �� Unity �����ڹ��� 2D ����Ӵ��Ľṹ�塣
    //�����ڶ�����ִ�����������������Ͷ�䡢��ײ���ȣ�ʱӦ�ÿ��ǵ������͹���ѡ��


    private float groundDistance = 0.15f;
    private float wallDistance = 0.2f;
    private float ceilingDistance = 0.05f;
    //���ߵ����Ͷ����룺һ������������ʾ���ߵ����Ͷ����롣

    BoxCollider2D touchingcol; //capsule(����) ������ײ��

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

    //����һ����Ϊ groundHits �����飬�����Դ洢��� 5 �� RaycastHit2D �ṹ���ʵ����
    //RaycastHit2D �ṹ��ͨ�����ڴ洢����Ͷ��Ľ�������������߻��е��������Ϣ������ײ�㡢��ײ���ߵȡ�

    //RaycastHit2D ��Ҫ����ִ������Ͷ�䲢��ȡ��ײ��Ϣ��
    //�����ʹ�� Unity �ṩ������Ͷ�亯������ Physics2D.Raycast��������һ�����ߣ�������ײ��Ϣ�洢�� RaycastHit2D �ṹ���С�
    //Ȼ������Լ����ײ�㡢���ߡ���������ԣ��Ա������Ҫִ����Ӧ�Ĳ������������ƶ��������¼��ȡ�


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
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;//Vector2.right���������ֵ�� (1, 0)   Vector2.left���������ֵ�� (-1, 0)
    //ͨ������ֵ����
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
        IsGrounded = touchingcol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;//Vector2.down��0��-1��
        IsOnWall = touchingcol.Cast(wallCheckDirection, castFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingcol.Cast(Vector2.up, castFilter, ceilingHits, ceilingDistance) > 0;//Vector2.up��0��1��
        //touchingcol.Cast ��һ���������ã�������ִ�� 2D ����Ͷ�䣬����Ƿ���������ָ���������ཻ
        //���ߵķ���ͨ����һ�� Vector2����ʾ���ߵķ������������� Vector2.down ��ʾ���·��䡣
        //���ߵĹ���������ͨ����һ�� ContactFilter2D�����ڶ�����Щ������Ա����߼�⵽�����԰����㼶����ײ�������Ϣ��
        //����Ͷ��Ľ����ͨ����һ�� RaycastHit2D ���飬���ڴ洢�����������ཻ����Ϣ��
        //���ߵ����Ͷ����룺һ������������ʾ���ߵ����Ͷ����롣
    }
    //��Ϸ���жϽ�ɫ�Ƿ񿿽�ǽ�ڡ��ذ塢�컨�壬��������Ҫִ����Ӧ�Ĳ�����������ֹ��ɫ������ǽ�ڻ��컨���ƶ��������ƽ̨��Ϸ�ͽ�ɫ���Ʒǳ����á�
}
