using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingControl : MonoBehaviour
{
    public SettingView view;

    private void Awake()
    {
        view = GetComponent<SettingView>();
    }

    private void Start()
    {
        view.butnSet.onClick.AddListener(Set);
        view.butnExit.onClick.AddListener(Exit);
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
