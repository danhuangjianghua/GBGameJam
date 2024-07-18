using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //UI名-存放路径
    Dictionary<string, string> n2pDic = new Dictionary<string, string>();
    //UI名-UI物体
    Dictionary<string, GameObject> n2oDic = new Dictionary<string, GameObject>();
    [Header("配置表路径")]
    [SerializeField] string configTable;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        TextAsset configText = Resources.Load<TextAsset>(configTable);
        if (configText == null) Debug.LogError("UI配置路径错误");
        UIConfigList uiConfigList = JsonUtility.FromJson<UIConfigList>(configText.text);
        foreach(var item in uiConfigList.UIConfigTable)
        {
            n2pDic.Add(item.uiName, item.path);
        }
    }

    public void openPanel(string gName)
    {
        if(n2oDic.ContainsKey(gName))
        {
            n2oDic[gName].SetActive(true);
            return;
        }
        n2oDic.Add(gName,Instantiate(readPrefab(n2pDic[gName]),transform));
        n2oDic[gName].SetActive(true);
    }

    public void closePanel(string gName)
    {
        if (n2oDic.ContainsKey(gName))
        {
            n2oDic[gName].SetActive(false);
            return;
        }
        Debug.LogWarning("不存在该UI，无法关闭");
    }

    public GameObject readPrefab(string path)
    {
        GameObject g= Resources.Load<GameObject>(path);
        if (g == null) Debug.LogError("UI预制体路径错误");
        return g;
    }
}
