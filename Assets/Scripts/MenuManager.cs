using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject window;
    private bool statusWindowActive = false;

    //MRTKのボタンからステータス画面を開くための関数
    public void StatusWindowOpen()
    {
        GameObject gameObject = GameObject.Find("StatusWindow");
        gameObject.GetComponent<StatusWindowManager>().StatusOpen();    //ステータス画面が開かれた際に実行する関数
    }

    public void ItemWindowOpen()
    {
        GameObject.Find("ItemWindow").GetComponent<ItemWindowManager>().ItemOpen();
    }

    //MRTKのボタンでactiveと非activeの状態を入れ替える関数
    public void WindowActiveCheck()
    {
        switch(statusWindowActive)
        {
            case true:
                window.SetActive(false);
                Time.timeScale = 1;         //ポーズ状態の解除
                statusWindowActive = false;
                break;
            case false:
                window.SetActive(true);
                Time.timeScale = 0;         //ポーズ状態
                statusWindowActive = true;
                break;
        }
    }
}
