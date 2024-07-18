using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoolBehavior : StateMachineBehaviour
{
    public string boolName;//�ⲿ����boolNameΪ��canMove����canMove= "canMove";��CanMove=canMove=boolName�Դ������ת��
    public bool updateOnstateMachine;//�ⲿ����false
    public bool updateOnState;//�ⲿ����true
    public bool valueOnEnter, valueOnExit;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //OnStateEnter ��һ�����ڼ��Ӷ���״̬����Ļص�������
    //stateInfo: ����һ�������йض���״̬����Ϣ�Ľṹ�塣���ṩ���йص�ǰ״̬�������Ϣ�������ơ�������ȫ������������
    //layerIndex: ���Ƕ���״̬���ڵĲ�����������Ƕ���״̬���е��߼����飬�������㽫����״̬�ֳɲ�ͬ�Ĳ�Ρ�
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateOnState)
        {
            animator.SetBool(boolName, valueOnEnter);//�ⲿ����ΪvalueOnEnterΪfalse
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
            animator.SetBool(boolName, valueOnExit);//�ⲿ����Ϊtrue
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
    //����Դ���״̬����State Machine�������嶯��״̬֮���ת�����߼���
    //OnStateMachineEnter ��һ������ĺ�����������״̬������ĳ��״̬��ʱ�������һ��״̬���뵽��һ��״̬��������������ᱻ���á�
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if (updateOnstateMachine)
        {
            animator.SetBool(boolName, valueOnEnter);
        }
    }
    //stateMachinePathHash������һ������ֵ����ʾ�����״̬����·���Ĺ�ϣ�롣
    //ÿ��״̬������һ��Ψһ��·����ϣ�룬���ڱ�ʶ��ͬ��״̬����
    //ͨ���Ƚ������ϣ�룬�����ȷ����������ĸ�״̬����

    //OnStateMachineEnter ����ͨ������ִ��һЩ��ʼ���߼������ö���״̬���ĳ�ʼ״̬��
    //���磬��������������������ĳ��Bool�����������ض���״̬ת�������߳�ʼ��һЩ������صı�����

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        if (updateOnstateMachine)
        {
            animator.SetBool(boolName, valueOnExit);
        }
    }
}
