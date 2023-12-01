using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject window;
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
        switch(window.activeSelf)
        {
            case true:
                window.SetActive(false);
                Time.timeScale = 1;         //�|�[�Y��Ԃ̉���
                break;
            case false:
                window.SetActive(true);
                Time.timeScale = 0;         //�|�[�Y���
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
