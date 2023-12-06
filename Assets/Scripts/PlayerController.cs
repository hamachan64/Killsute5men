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
    public int currentHP;   //����HP
    public int currentMP;   //����MP
    private int damage;

    [SerializeField] ItemWindowManager itemWindowManager;

    void Start()
    {
        //����HP�̃Z�b�g
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

    //Object��Trigger�Փ˔���
    private void OnTriggerEnter(Collider col)   //private void OnCollisionEnter(Collision collision)�Ȃ�Փ˔���
    {
        //Enemy�̍U�� ���̔��肪�����Ȃ�col.gameObject.CompareTag("Enemy")�Ń]���r���������̕����ǂ�����
        if (col.gameObject.CompareTag("EnemyWeapon"))
        {
            EnemyAttack(0);
        }

        //�A�C�e���̊l��
        if (col.gameObject.CompareTag("Item"))
        {
            itemWindowManager.GetComponent<ItemWindowManager>().getItem = col.gameObject.GetComponent<ItemManager>().itemNum;   //
            itemWindowManager.GetComponent<ItemWindowManager>().ItemGet();
            Destroy(col.gameObject);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        //Enemy�̍U��
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("aaaaaaaaaaaaa");
            EnemyAttack(1);
            //StartCoroutine("EnemyAttack");
            //InvokeRepeating("EnemyAttack", 0, 2);
        }

    }

    void EnemyAttack(int i)
    {
        //�_���[�W����
        damage = (int)(enemyStatusSO.enemyStatusList[i].Attack / 2 - playerStatusSO.Defence / 4);

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


    public void SetHPBar()
    {
        _hpText.GetComponent<TextMeshProUGUI>().text = currentHP.ToString();
        _hpSlider.value = currentHP;
    }

    public void SetMPBar()
    {
        _mpText.GetComponent<TextMeshProUGUI>().text = currentMP.ToString();
        _mpSlider.value = currentMP;
    }
}
