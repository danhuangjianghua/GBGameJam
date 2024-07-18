using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTTree : MonoBehaviour
{
    [HideInInspector]
    public BTNode root;
    [HideInInspector]
    public DataBase db;
    // Start is called before the first frame update
    public virtual void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (root != null && root.Evaluate()) root.Process();
    }

    public virtual void Init()
    {
        db=GetComponent<DataBase>();
        root.Activate(db);
    }

}
