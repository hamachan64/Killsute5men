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

    //�Q�[���X�^�[�g���ɕ\������e�L�X�g
    void Start()
    {
        talkWindow.SetActive(true);
        //Debug.Log(eventSO.eventsList.Count);

        StartCoroutine("EventProgress");

    }

    //eventList�ɐݒ肵���e�L�X�g��i�K�I�ɃZ�b�g���ĕ\������
    IEnumerator EventProgress()
    {
        for (int i = 0; i < eventSO.eventsList.Count; i++)
        {
            talkText.GetComponent<TextMeshProUGUI>().text = eventSO.eventsList[i].EventDescription;
            progressFlag++;
            yield return new WaitForSeconds(5);
        }

        //�e�L�X�g�����ׂĕ\������������Destroy
        Destroy(talkWindow);
    }

}
