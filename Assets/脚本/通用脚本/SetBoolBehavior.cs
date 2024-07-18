using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolBehavior : StateMachineBehaviour
{
    public string boolName;//外部设置boolName为“canMove”和canMove= "canMove";即CanMove=canMove=boolName以此来完成转递
    public bool updateOnstateMachine;//外部设置false
    public bool updateOnState;//外部设置true
    public bool valueOnEnter, valueOnExit;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //OnStateEnter 是一个用于监视动画状态进入的回调函数。
    //stateInfo: 这是一个包含有关动画状态的信息的结构体。它提供了有关当前状态的许多信息，如名称、短名、全名、层索引等
    //layerIndex: 这是动画状态所在的层的索引。层是动画状态机中的逻辑分组，它允许你将动画状态分成不同的层次。
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnState)
        {
            animator.SetBool(boolName, valueOnEnter);//外部设置为valueOnEnter为false
        }
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnState)
        {
            animator.SetBool(boolName, valueOnExit);//外部设置为true
        }
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //你可以创建状态机（State Machine）来定义动画状态之间的转换和逻辑。
    //OnStateMachineEnter 是一个特殊的函数，当动画状态机进入某个状态机时（例如从一个状态进入到另一个状态机），这个函数会被调用。
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if (updateOnstateMachine)
        {
            animator.SetBool(boolName, valueOnEnter);
        }
    }
    //stateMachinePathHash：这是一个整数值，表示进入的状态机的路径的哈希码。
    //每个状态机都有一个唯一的路径哈希码，用于标识不同的状态机。
    //通过比较这个哈希码，你可以确定进入的是哪个状态机。

    //OnStateMachineEnter 函数通常用于执行一些初始化逻辑或设置动画状态机的初始状态。
    //例如，你可以在这个函数中设置某个Bool参数来触发特定的状态转换，或者初始化一些动画相关的变量。

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (updateOnstateMachine)
        {
            animator.SetBool(boolName, valueOnExit);
        }
    }
}
