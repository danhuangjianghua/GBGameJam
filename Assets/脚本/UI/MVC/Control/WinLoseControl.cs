using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseControl : MonoBehaviour
{
    WinLoseView view;
    public string reTry;
    public string next;

    private void Awake()
    {
        view = GetComponent<WinLoseView>();
    }

    private void Start()
    {
        view.butnReTry.onClick.AddListener(tryAgain);
        view.butnNext.onClick.AddListener(nextLevel);
        view.butnReturn1.onClick.AddListener(returnMainInterface);
        view.butnReturn2.onClick.AddListener(returnMainInterface);
    }

    public void nextLevel()
    {
        Time.timeScale = 1;
        SceneManage.Manager.ChangeScene(next);
    }

    public void tryAgain()
    {
        Time.timeScale = 1;
        SceneManage.Manager.ChangeScene(reTry);
    }

    public void returnMainInterface()
    {
        SceneManage.Manager.ChangeScene("MainInterface");
    }
}
