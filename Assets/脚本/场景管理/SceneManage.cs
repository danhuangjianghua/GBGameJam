using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    private static SceneManage manager = null;
    public static SceneManage Manager
    {
        get
        {
            return manager;
        }
    }

    [Header("��ʼ��ת����")]
    [SerializeField] string initSceneName;

    SceneManage()
    {
        if(manager==null)
        {
            manager = this;
        }
    }

    [Header("���ɳ���")]
    [SerializeField] string transition;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        ChangeScene(initSceneName);
    }

    public void ChangeScene(string sceneName)
    {
        GetComponent<LoopMusic>().Check(sceneName);
        SceneManager.LoadScene(transition);
        StartCoroutine("loadSceneAsyn", sceneName);
    }

    IEnumerator loadSceneAsyn(string sceneName)
    {
        while (SceneManager.GetActiveScene().name != transition) yield return null;
        GC.Collect();
        AsyncOperation asyncOperation= SceneManager.LoadSceneAsync(sceneName);
        while(!asyncOperation.isDone)
        {
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }
}
