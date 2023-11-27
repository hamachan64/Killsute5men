using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class ItemWindowManager : MonoBehaviour
{
    [SerializeField] ItemsSO itemsSO;
    [SerializeField] TextMeshProUGUI itemText;
    [SerializeField] TextMeshPro coinText;
    [SerializeField] TextMeshPro portionText;
    public int getItem;           //�Q�b�g����A�C�e���̔ԍ�
    public int[] itemQtyArray;    //�e�A�C�e���̏��������i�[����z��
    private string itemOpenText;
    private string itemType;


    void Start()
    {
        itemQtyArray = new int[itemsSO.itemList.Count];     // ItemsSO�̃��X�g�̗v�f���Ɣz��̗v�f�������낦��
    }
   
    //�A�C�e�����Q�b�g�����Ƃ��̊֐�
    public void ItemGet()
    {
        //�l���A�C�e���̏��������v���X
        itemQtyArray[getItem] = itemQtyArray[getItem] + 1;
    }

    public void ItemOpen()
    {
        coinText.GetComponent<TextMeshPro>().text = itemQtyArray[0].ToString();
        portionText.GetComponent<TextMeshPro>().text = itemQtyArray[1].ToString();
    }

    public void ItemUse(int itemNum)
    {
        //itemType = itemsSO.itemList[itemNum].ItemType.Tostring();
    }
}