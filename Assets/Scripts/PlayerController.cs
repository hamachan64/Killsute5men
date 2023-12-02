using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _hpText;
    [SerializeField] TextMeshProUGUI _mpText;
    [SerializeField] Slider _hpSlider;
    [SerializeField] Slider _mpSlider;
    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] EnemyStatusSO enemyStatusSO;
    public int currentHP;   //現在HP
    public int currentMP;   //現在MP
    private int damage;

    [SerializeField] ItemWindowManager itemWindowManager;

    void Start()
    {
        //初期HPのセット
        currentHP = playerStatusSO.HP;
        currentMP = playerStatusSO.MP;
        _hpText.GetComponent<TextMeshProUGUI>().text = currentHP.ToString();
        _mpText.GetComponent<TextMeshProUGUI>().text = currentMP.ToString();
        _hpSlider.maxValue = playerStatusSO.HP;
        _hpSlider.value = currentHP;
        _mpSlider.maxValue = playerStatusSO.MP;
        _mpSlider.value = currentMP;
    }

    void Update()
    {
        //_hpText.GetComponent<TextMeshProUGUI>().text = currentHP.ToString();
        //_hpSlider.value = currentHP;
        _mpText.GetComponent<TextMeshProUGUI>().text = currentMP.ToString();
        //_mpSlider.value = currentMP;

    }

    //ObjectのTrigger衝突判定
    private void OnTriggerEnter(Collider col)   //private void OnCollisionEnter(Collision collision)なら衝突判定
    {
        //Enemyの攻撃
        if (col.gameObject.CompareTag("EnemyWeapon"))
        {
            //ダメージ調整
            damage = (int)(enemyStatusSO.enemyStatusList[0].Attack / 2 - playerStatusSO.Defence / 4);

            if (damage > 0)
            {
                if (currentHP > damage)
                {
                    currentHP -= damage;
                }
                else
                {
                    currentHP = 0;
                }
                SetHPBar();
            }
        }

        //アイテムの獲得
        if (col.gameObject.CompareTag("Item"))
        {
            itemWindowManager.GetComponent<ItemWindowManager>().getItem = col.gameObject.GetComponent<ItemManager>().itemNum;   //
            itemWindowManager.GetComponent<ItemWindowManager>().ItemGet();

            //switch (col.gameObject.GetComponent<ItemManager>().itemNum)
            //{
            //    case 0:
            //        portion += 1;
            //        portionText.GetComponent<TextMeshPro>().text = portion.ToString();
            //        break;
            //    case 1:
            //        coin += 1;
            //        coinText.GetComponent<TextMeshPro>().text = coin.ToString();
            //        break;

            //}

            Destroy(col.gameObject);
        }
    }

    public void SetHPBar()
    {
        _hpText.GetComponent<TextMeshProUGUI>().text = currentHP.ToString();
        _hpSlider.value = currentHP;
    }
}
