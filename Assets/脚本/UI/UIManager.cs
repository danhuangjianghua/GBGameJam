using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    //UI��-���·��
    Dictionary<string, string> n2pDic = new Dictionary<string, string>();
    //UI��-UI����
    Dictionary<string, GameObject> n2oDic = new Dictionary<string, GameObject>();
    [Header("���ñ�·��")]
    [SerializeField] string configTable;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        TextAsset configText = Resources.Load<TextAsset>(configTable);
        if (configText == null) Debug.LogError("UI����·������");
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
        Debug.LogWarning("�����ڸ�UI���޷��ر�");
    }

    public GameObject readPrefab(string path)
    {
        GameObject g= Resources.Load<GameObject>(path);
        if (g == null) Debug.LogError("UIԤ����·������");
        return g;
    }
}
