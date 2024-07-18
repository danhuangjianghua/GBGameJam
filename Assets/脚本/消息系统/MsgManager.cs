using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/// <summary>
/// 消息管理中心，负责事件的订阅、移除和发布
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
            Debug.LogError("不存在该消息，无法移除监听者！！！");
            return;
        }
        if (msgDic[msg].Count==0)
        {
            Debug.LogError("不存在任何监听者，无法移除！！！");
            return;
        }
        if (!msgDic[msg].Contains(handler))
        {
            Debug.LogError("不存在对应监听者，无法移除！！！");
            return;
        }
        msgDic[msg].Remove(handler);
    }

    public void sendMessage(MsgName msg,object sender,EventArgs args)
    {
        if(!msgDic.ContainsKey(msg))
        {
            Debug.LogError("不存在该消息，无法发布信息！！！");
            return;
        }
        List<EventHandler> temp = msgDic[msg];
        foreach(var item in temp)
        {
            item?.Invoke(sender, args);
        }
    }
}
