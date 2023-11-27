using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _hpText;
    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] EnemyStatusSO enemyStatusSO;
    public int currentHP;
    private int damage;

    [SerializeField] ItemWindowManager itemWindowManager;

    void Start()
    {
        //����HP�̃Z�b�g
        currentHP = playerStatusSO.HP;
        _hpText.GetComponent<TextMeshProUGUI>().text = "HP : " + currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        _hpText.GetComponent<TextMeshProUGUI>().text = "HP : " + currentHP;
    }

    //Object��Trigger�Փ˔���
    private void OnTriggerEnter(Collider col)   //private void OnCollisionEnter(Collision collision)�Ȃ�Փ˔���
    {
        //Enemy�̍U��
        if (col.gameObject.CompareTag("EnemyWeapon"))
        {
            //�_���[�W����
            damage = (int)(enemyStatusSO.enemyStatusList[0].Attack / 2 - playerStatusSO.Defence / 4);

            if (damage > 0)
            {
                currentHP -= damage;
            }
        }

        //�A�C�e���̊l��
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
}
