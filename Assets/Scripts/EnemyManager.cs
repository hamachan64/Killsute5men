using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;

    private int currentHP;
    private int damage;

    private NavMeshAgent agent;
    private Animator animator;
    private float speed = 2.0f;
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        //初期HPのセット
        currentHP = enemyStatusSO.enemyStatusList[0].HP;

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.speed = speed;
        animator.SetBool("Attack", false);
        animator.SetBool("Death", false);

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, this.transform.position);

        agent.destination = target.position;

        if (distance >= 0 && distance < 2)
        {
            animator.SetBool("Attack", true);
        }

        if (distance >= 2)
        {
            animator.SetBool("Attack", false);
        }

        if (currentHP <= 0)
        {
            animator.SetBool("Death", true);

            Destroy(this.gameObject, 5.0f);
        }

    }

    private void OnTriggerEnter(Collider col)
    {
        //武器の衝突限定
        if (col.gameObject.CompareTag("Weapon"))
        {
            //ダメージ調整
            damage = (int)(playerStatusSO.Attack / 2 - enemyStatusSO.enemyStatusList[0].Defence / 4);

            if (damage > 0)
            {
                currentHP -= damage;
            }
            Debug.Log(currentHP);
        }
    }
}
