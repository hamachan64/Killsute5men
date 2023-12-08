using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//GameMasterでAddComponent
public class MasterManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI talkText;
    [SerializeField] TextMeshProUGUI talkPerson;
    [SerializeField] GameObject talkWindow;
    [SerializeField] EventSO eventSO;

    [SerializeField] GameObject sword;
    [SerializeField] GameObject spawner;
    [SerializeField] GameObject status;

    [SerializeField] bool progressFlag;

    //ゲームスタート時に表示するテキスト
    void Start()
    {
        //最初はWindowだけ表示する
        talkWindow.SetActive(true);
        sword.SetActive(false);
        spawner.SetActive(false);
        status.SetActive(false);

        //Sceneで出すテキストを分ける
        if(progressFlag)
        {
            StartCoroutine("EventProgress");
        }
        else
        {
            StartCoroutine("GameClear");
        }

    }

    //eventListに設定したテキストを段階的にセットして表示する
    //Mainで動くイベント
    IEnumerator EventProgress()
    {

        for (int i = 0; i < eventSO.eventsList.Count - 1; i++)
        {
            talkText.GetComponent<TextMeshProUGUI>().text = eventSO.eventsList[i].EventDescription;
            talkPerson.GetComponent<TextMeshProUGUI>().text = eventSO.eventsList[i].PersonName;
            yield return new WaitForSeconds(3);
        }

        progressFlag = true;

        //テキストをすべて表示しきった後の動作
        Destroy(talkWindow);
        sword.SetActive(true);
        spawner.SetActive(true);
        status.SetActive(true);
    }

    //Clearで動くイベント
    IEnumerator GameClear()
    {
        talkText.GetComponent<TextMeshProUGUI>().text = eventSO.eventsList[9].EventDescription;
        talkPerson.GetComponent<TextMeshProUGUI>().text = eventSO.eventsList[9].PersonName;
        yield return new WaitForSeconds(3);

        Destroy(talkWindow);
    }

}
