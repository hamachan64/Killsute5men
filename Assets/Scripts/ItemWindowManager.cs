using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

//NearMenuでAddComponent
public class ItemWindowManager : MonoBehaviour
{
    [SerializeField] ItemsSO itemsSO;
    //[SerializeField] TextMeshProUGUI itemText;

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
        ItemOpen();
    }

    //ItemWindowが開かれた際にItemの個数をそろえる
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