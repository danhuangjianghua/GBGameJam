using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainInterfaceControl : MonoBehaviour
{
    MainInterfaceView view;

    private void Awake()
    {
        view = GetComponent<MainInterfaceView>();
    }

    private void Start()
    {
        view.butnPlay.onClick.AddListener(Play);
        view.butnExit.onClick.AddListener(Exit);
        view.butnSet.onClick.AddListener(Set);
    }

    public void Play()
    {
        SceneManage.Manager.ChangeScene("Leve1");
    }

    public void Set()
    {
        AudioManager.audioManager.openAudioSetting();
    }

    public void Exit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                            Application.Quit();
        #endif
    }
}
