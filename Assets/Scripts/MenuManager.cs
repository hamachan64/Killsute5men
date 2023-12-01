using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject window;
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
        switch(window.activeSelf)
        {
            case true:
                window.SetActive(false);
                Time.timeScale = 1;         //ポーズ状態の解除
                break;
            case false:
                window.SetActive(true);
                Time.timeScale = 0;         //ポーズ状態
                break;
        }
    }

    void MainToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    void TitleToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
