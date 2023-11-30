using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusWindowManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _hpValue;
    [SerializeField] TextMeshProUGUI _maxHpValue;
    [SerializeField] TextMeshProUGUI _mpValue;
    [SerializeField] TextMeshProUGUI _maxMpValuse;
    [SerializeField] TextMeshProUGUI _attackValue;
    [SerializeField] TextMeshProUGUI _defenseValue;
    [SerializeField] PlayerStatusSO playerStatusSO;

    private int currentMP;
    private int currentAttack;
    private int currentDefense;

    void Start()
    {
        
        currentMP = playerStatusSO.MP;
        currentAttack = playerStatusSO.Attack;
        currentDefense = playerStatusSO.Defence;

        //_hpValue.GetComponent<TextMeshProUGUI>().text = playerController.currentHP.ToString();
        _maxHpValue.GetComponent<TextMeshProUGUI>().text = playerStatusSO.HP.ToString();
        _mpValue.GetComponent<TextMeshProUGUI>().text = currentMP.ToString();
        _maxMpValuse.GetComponent<TextMeshProUGUI>().text = playerStatusSO.MP.ToString();
        _attackValue.GetComponent<TextMeshProUGUI>().text = currentAttack.ToString();
        _defenseValue.GetComponent<TextMeshProUGUI>().text = currentDefense.ToString();
    }

    public void StatusOpen()
    {

        //プレーヤーのHPを取ってきて，ステータス画面に表示
        _hpValue.GetComponent<TextMeshProUGUI>().text = GameObject.Find("Main Camera").GetComponent<PlayerController>().currentHP.ToString();
    }
}
