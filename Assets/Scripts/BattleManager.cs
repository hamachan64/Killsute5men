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
        //•Ší‚ÌÕ“ËŒÀ’è
        if (col.gameObject.CompareTag("Weapon"))
        {
            //ƒ_ƒ[ƒW’²®
            damage = (int)(playerStatusSO.Attack / 2 - enemyStatusSO.enemyStatusList[0].Defence / 4);

            if (damage > 0)
            {
                currentHP -= damage;
            }
            Debug.Log(currentHP);
        }
    }
}
