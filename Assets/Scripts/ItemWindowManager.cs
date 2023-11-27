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
    public int getItem;           //ゲットするアイテムの番号
    public int[] itemQtyArray;    //各アイテムの所字数を格納する配列
    private string itemOpenText;
    private string itemType;


    void Start()
    {
        itemQtyArray = new int[itemsSO.itemList.Count];     // ItemsSOのリストの要素数と配列の要素数をそろえる
    }
   
    //アイテムをゲットしたときの関数
    public void ItemGet()
    {
        //獲得アイテムの所字数をプラス
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