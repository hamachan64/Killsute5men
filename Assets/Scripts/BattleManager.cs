using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyStatusSO;

public class BattleManager : MonoBehaviour
{
    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] EnemyStatusSO enemyStatusSO;
    public int damage;
    public int currentHP;
    
    void OnTriggerEnter(Collider col)
    {
        //����̏Փˌ���
        if (col.gameObject.CompareTag("Weapon"))
        {
            //�_���[�W����
            damage = (int)(playerStatusSO.Attack / 2 - enemyStatusSO.enemyStatusList[0].Defence / 4);

            if (damage > 0)
            {
                currentHP -= damage;
            }
            Debug.Log(currentHP);
        }
    }
}
