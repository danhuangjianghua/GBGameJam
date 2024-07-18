using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct configData
{
    public string uiName;
    public string path;
}

[Serializable]
public class UIConfigList
{
    public List<configData> UIConfigTable= new List<configData>();
}
