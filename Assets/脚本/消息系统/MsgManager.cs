using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/// <summary>
/// ��Ϣ�������ģ������¼��Ķ��ġ��Ƴ��ͷ���
/// </summary>
public class MsgManager : MonoBehaviour
{
    private static MsgManager manager = null;
    public static MsgManager msgManager
    {
        get
        {
            return manager;
        }
    }

    Dictionary<MsgName, List<EventHandler>> msgDic = new Dictionary<MsgName, List<EventHandler>>();

    private void Awake()
    {
        if(manager==null)
        {
            manager = this;
        }
    }

    public void addListener(MsgName msg,EventHandler handler)
    {
        if(msgDic.ContainsKey(msg))
        {
            msgDic[msg].Add(handler);
        }
        else
        {
            List<EventHandler> handlers = new List<EventHandler>();
            handlers.Add(handler);
            msgDic.Add(msg, handlers);
        }
    }

    public void removeListener(MsgName msg, EventHandler handler)
    {
        if(!msgDic.ContainsKey(msg))
        {
            Debug.LogError("�����ڸ���Ϣ���޷��Ƴ������ߣ�����");
            return;
        }
        if (msgDic[msg].Count==0)
        {
            Debug.LogError("�������κμ����ߣ��޷��Ƴ�������");
            return;
        }
        if (!msgDic[msg].Contains(handler))
        {
            Debug.LogError("�����ڶ�Ӧ�����ߣ��޷��Ƴ�������");
            return;
        }
        msgDic[msg].Remove(handler);
    }

    public void sendMessage(MsgName msg,object sender,EventArgs args)
    {
        if(!msgDic.ContainsKey(msg))
        {
            Debug.LogError("�����ڸ���Ϣ���޷�������Ϣ������");
            return;
        }
        List<EventHandler> temp = msgDic[msg];
        foreach(var item in temp)
        {
            item?.Invoke(sender, args);
        }
    }
}
