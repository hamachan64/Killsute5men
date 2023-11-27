using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject window;
    private bool statusWindowActive = false;

    //MRTK�̃{�^������X�e�[�^�X��ʂ��J�����߂̊֐�
    public void StatusWindowOpen()
    {
        GameObject gameObject = GameObject.Find("StatusWindow");
        gameObject.GetComponent<StatusWindowManager>().StatusOpen();    //�X�e�[�^�X��ʂ��J���ꂽ�ۂɎ��s����֐�
    }

    public void ItemWindowOpen()
    {
        GameObject.Find("ItemWindow").GetComponent<ItemWindowManager>().ItemOpen();
    }

    //MRTK�̃{�^����active�Ɣ�active�̏�Ԃ����ւ���֐�
    public void WindowActiveCheck()
    {
        switch(statusWindowActive)
        {
            case true:
                window.SetActive(false);
                Time.timeScale = 1;         //�|�[�Y��Ԃ̉���
                statusWindowActive = false;
                break;
            case false:
                window.SetActive(true);
                Time.timeScale = 0;         //�|�[�Y���
                statusWindowActive = true;
                break;
        }
    }
}
