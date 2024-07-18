using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float walkspeed;//走路速度
    public float Walkspeed { get => walkspeed; set => walkspeed = value; }
    public int i;
    public GameObject[] InBox;
    public AudioSource audioSourceWalk;
    public AudioSource audioSource;
    OutBox OutBox;
    private int can_Eat=1;

    public bool CanEat
    {
        get
        {
            if (can_Eat == PlayerPrefs.GetInt("CanEat"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private Vector2 input;
    //private Vector2 mousePostion;
    private new Rigidbody2D rigidbody2D;
    Animator animator;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        OutBox = GetComponent<OutBox>();
    }

    private void Update()
    {
        rigidbody2D.velocity= input.normalized * Walkspeed;
        PlayerLook();
        if (input != Vector2.zero)
        {
            animator.SetBool("isMove", true);
            if(input.normalized.y==1f)
            {
                animator.SetBool(AnimationString.upRun, true);
            }
            else if(input.normalized.y==-1f) 
            {
                animator.SetBool(AnimationString.downRun, true);
            }
            else if(input.normalized.x==1f||input.normalized.x==-1f) 
            {
                animator.SetBool(AnimationString.adRun, true);
            }
        }
        else
        {
            animator.SetBool("isMove", false);
        }

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("w_run") || stateInfo.IsName("w_Idle"))
        {
            // 在这里执行与特定动画状态相关的操作
            i = 1;
        }
        else if (stateInfo.IsName("s_run") || stateInfo.IsName("s_Idle"))
        {
            i = 2;
        }
        else if (stateInfo.IsName("ad_run") || stateInfo.IsName("ad_Idle"))
        {
            i = 0;
        }
        else
        {
            Debug.Log("not found 动画状态");
        }

    }

    void PlayerLook()
    {
        //mousePostion = Mouse.current.position.ReadValue();//捕捉屏幕鼠标位置
        //mousePostion = Camera.main.ScreenToWorldPoint(mousePostion);//转为世界坐标
        if(input.x<0) 
        {
            this.transform.localScale = new Vector3(-1.0f,1f,1f);
        }
        else if(input.x>0)
        {
            this.transform.localScale = new Vector3(1.0f,1f,1f);
        }

    }

    public void OnMove(InputAction.CallbackContext context)
   {
        input = context.ReadValue<Vector2>();
        if (context.started)
        {
            audioSourceWalk.loop = true;
            audioSourceWalk.Play();
        }
        if(context.canceled)
        {
            audioSourceWalk.Stop();
        }
      
    }
    public void OnEat(InputAction.CallbackContext context)
    {//吞入盒子
        
           if(context.started&&CanEat)
           {
            InBox[i].SetActive(true);
             
           }
           if(context.canceled)
           {
              InBox[i].SetActive(false);
           }
        
    }

    public void OutEat(InputAction.CallbackContext context)
    {//吐出盒子
        if (context.started&&CanEat==false)
        {
            OutBox.FireProjectile();
            PlayerPrefs.SetInt("CanEat", 1);
            AudioSource.PlayClipAtPoint(audioSource.clip, gameObject.transform.position, audioSource.volume);
        }
    }

    public void Die()
    {
        MsgManager.msgManager.sendMessage(MsgName.Lose, this, null);
        gameObject.SetActive(false);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            if (!((BaseBehavior)collision.gameObject.GetComponent<Enemy>().behaviorDic[EnemyDataType.BaseData]).isDizzy) Die();
        }
    }
}
