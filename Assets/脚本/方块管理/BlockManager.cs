using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public List<GameObject> blocks = new List<GameObject>();

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        for(int i=0;i<transform.childCount;++i)
        {
            blocks.Add(transform.GetChild(i).gameObject);
        }
    }
}
