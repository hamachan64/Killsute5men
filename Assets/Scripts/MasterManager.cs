using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//GameMaster��AddComponent
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

    //�Q�[���X�^�[�g���ɕ\������e�L�X�g
    void Start()
    {
        //�ŏ���Window�����\������
        talkWindow.SetActive(true);
        sword.SetActive(false);
        spawner.SetActive(false);
        status.SetActive(false);

        //Scene�ŏo���e�L�X�g�𕪂���
        if(progressFlag)
        {
            StartCoroutine("EventProgress");
        }
        else
        {
            StartCoroutine("GameClear");
        }

    }

    //eventList�ɐݒ肵���e�L�X�g��i�K�I�ɃZ�b�g���ĕ\������
    //Main�œ����C�x���g
    IEnumerator EventProgress()
    {

        for (int i = 0; i < eventSO.eventsList.Count - 1; i++)
        {
            talkText.GetComponent<TextMeshProUGUI>().text = eventSO.eventsList[i].EventDescription;
            talkPerson.GetComponent<TextMeshProUGUI>().text = eventSO.eventsList[i].PersonName;
            yield return new WaitForSeconds(3);
        }

        progressFlag = true;

        //�e�L�X�g�����ׂĕ\������������̓���
        Destroy(talkWindow);
        sword.SetActive(true);
        spawner.SetActive(true);
        status.SetActive(true);
    }

    //Clear�œ����C�x���g
    IEnumerator GameClear()
    {
        talkText.GetComponent<TextMeshProUGUI>().text = eventSO.eventsList[9].EventDescription;
        talkPerson.GetComponent<TextMeshProUGUI>().text = eventSO.eventsList[9].PersonName;
        yield return new WaitForSeconds(3);

        Destroy(talkWindow);
    }

}
