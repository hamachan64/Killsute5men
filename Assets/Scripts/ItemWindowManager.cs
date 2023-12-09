using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

//NearMenu��AddComponent
public class ItemWindowManager : MonoBehaviour
{
    [SerializeField] ItemsSO itemsSO;
    //[SerializeField] TextMeshProUGUI itemText;

    //ItemWindow�̃A�C�e�����̃e�L�X�g
    [SerializeField] TextMeshPro portionText;
    [SerializeField] TextMeshPro atkPortionText;
    [SerializeField] TextMeshPro defPortionText;
    [SerializeField] TextMeshPro coinText;

    [SerializeField] GameObject player;
    [SerializeField] GameObject itemPanel;
    public int getItem;           //�Q�b�g����A�C�e���̔ԍ�
    public int[] itemQtyArray;    //�e�A�C�e���̏��������i�[����z��
    private string itemOpenText;
    private string itemType;


    void Start()
    {
        itemQtyArray = new int[itemsSO.itemList.Count - 1];     // ItemsSO�̃��X�g�̗v�f���Ɣz��̗v�f�������낦��
        itemPanel.SetActive(false);
    }

    //�A�C�e�����Q�b�g�����Ƃ��̊֐�
    public void ItemGet()
    {
        Debug.Log(getItem);
        //�l���A�C�e���̏��������v���X
        itemQtyArray[getItem] = itemQtyArray[getItem] + 1;
        ItemOpen();
    }

    //ItemWindow���J���ꂽ�ۂ�Item�̌������낦��
    public void ItemOpen()
    {
        portionText.GetComponent<TextMeshPro>().text = itemQtyArray[0].ToString();
        atkPortionText.GetComponent<TextMeshPro>().text = itemQtyArray[1].ToString();
        defPortionText.GetComponent<TextMeshPro>().text = itemQtyArray[2].ToString();
        coinText.GetComponent<TextMeshPro>().text = itemQtyArray[3].ToString();

    }

    //Item���g��ꂽ����Window��Item�����Ǘ�����֐�
    public void ItemUsed(int itemNo)
    {
        itemType = itemsSO.itemList[itemNo].ItemType.ToString();

        if (itemQtyArray[itemNo] > 0)
        {
            itemQtyArray[itemNo] -= 1;

            switch (itemType)
            {
                case "recovery":
                    if (player.GetComponent<PlayerController>().currentHP > 150)
                    {
                        player.GetComponent<PlayerController>().currentHP = 200;
                    }
                    else
                    {
                        player.GetComponent<PlayerController>().currentHP += itemsSO.itemList[itemNo].ItemEffect;
                    }
                    ItemOpen();
                    player.GetComponent<PlayerController>().SetHPBar();
                    GameObject.Find("StatusWindow").GetComponent<StatusWindowManager>().StatusOpen();
                    break;
                case "attackTool":
                    break;
                case "defenseTool":
                    break;
                case "coin":
                    player.GetComponent<PlayerController>().currentHP = 200;
                    ItemOpen();
                    player.GetComponent<PlayerController>().SetHPBar();
                    GameObject.Find("StatusWindow").GetComponent<StatusWindowManager>().StatusOpen();
                    break;
            }
        }
        else
        {
            //Debug.Log(itemQtyArray[itemNo]);
        }

    }
}