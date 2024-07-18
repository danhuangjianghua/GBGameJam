using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    Dictionary<string, object> datas = new Dictionary<string, object>();

    [Header("ÎÄ¼þÃû")]
    public string fileName;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("o");
            foreach (var item in datas) Debug.Log(item.Key+" "+item.Value);
        }
    }

    public T GetData<T>(string key)
    {
        if(!datas.ContainsKey(key)) Debug.LogError("The data does not exit!");
        return (T)datas[key];
    }

    public void DeleteData(string key)
    {
        if (datas.ContainsKey(key)) datas.Remove(key);
    }

    public void AddData<T>(string key,T value)
    {
        if (datas.ContainsKey(key)) datas[key] = (object)value;
        else datas.Add(key, (object)value);
    }
}
