using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MasterManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI talkText;
    [SerializeField] GameObject talkWindow;
    [SerializeField] EventSO eventSO;

    private int progressFlag = 0;
    //private string currentText;

    //ゲームスタート時に表示するテキスト
    void Start()
    {
        talkWindow.SetActive(true);
        //Debug.Log(eventSO.eventsList.Count);

        StartCoroutine("EventProgress");

    }

    //eventListに設定したテキストを段階的にセットして表示する
    IEnumerator EventProgress()
    {
        for (int i = 0; i < eventSO.eventsList.Count; i++)
        {
            talkText.GetComponent<TextMeshProUGUI>().text = eventSO.eventsList[i].EventDescription;
            progressFlag++;
            yield return new WaitForSeconds(5);
        }

        //テキストをすべて表示しきったらDestroy
        Destroy(talkWindow);
    }

}
