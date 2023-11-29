using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class ItemWindowManager : MonoBehaviour
{
    [SerializeField] ItemsSO itemsSO;
    [SerializeField] TextMeshProUGUI itemText;

    //ItemWindowのアイテム個数のテキスト
    [SerializeField] TextMeshPro portionText;
    [SerializeField] TextMeshPro atkPortionText;
    [SerializeField] TextMeshPro defPortionText;
    [SerializeField] TextMeshPro coinText;

    [SerializeField] GameObject player;
    [SerializeField] GameObject itemPanel;
    public int getItem;           //ゲットするアイテムの番号
    public int[] itemQtyArray;    //各アイテムの所字数を格納する配列
    private string itemOpenText;
    private string itemType;


    void Start()
    {
        itemQtyArray = new int[itemsSO.itemList.Count - 1];     // ItemsSOのリストの要素数と配列の要素数をそろえる
        itemPanel.SetActive(false);
    }

    //アイテムをゲットしたときの関数
    public void ItemGet()
    {
        Debug.Log(getItem);
        //獲得アイテムの所字数をプラス
        itemQtyArray[getItem] = itemQtyArray[getItem] + 1;
    }

    //ItemWindowが開かれた際の操作
    public void ItemOpen()
    {
        portionText.GetComponent<TextMeshPro>().text = itemQtyArray[0].ToString();
        atkPortionText.GetComponent<TextMeshPro>().text = itemQtyArray[1].ToString();
        defPortionText.GetComponent<TextMeshPro>().text = itemQtyArray[2].ToString();
        coinText.GetComponent<TextMeshPro>().text = itemQtyArray[3].ToString();

    }

    //Itemが使われた時にWindowのItem数を管理する関数
    public void ItemUsed(int itemNo)
    {
        itemType = itemsSO.itemList[itemNo].ItemType.ToString();
        //mainplayer = player;

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
                    break;
                case "attackTool":
                    break;
                case "defenseTool":
                    break;
                case "coin":
                    break;
            }
        }
        else
        {
            Debug.Log(itemQtyArray[itemNo]);
        }

    }
}