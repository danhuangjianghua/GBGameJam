using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgInit : MonoBehaviour
{
    public GameObject winFrame;
    public GameObject loseFrame;
    public int enemyCount;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        enemyCount = transform.childCount;
        MsgManager.msgManager.addListener(MsgName.Win, gameWin);
        MsgManager.msgManager.addListener(MsgName.Lose, gameLose);
        MsgManager.msgManager.addListener(MsgName.EnemyDie, enemyDie);
    }

    public void gameWin(object sender,EventArgs e)
    {
        Time.timeScale = 0;
        winFrame.SetActive(true);
    }

    public void gameLose(object sender, EventArgs e)
    {
        Time.timeScale = 0;
        loseFrame.SetActive(true);
    }

    public void enemyDie(object sender, EventArgs e)
    {
        enemyCount--;
        if (enemyCount <= 0) MsgManager.msgManager.sendMessage(MsgName.Win, this, null);
    }
}
