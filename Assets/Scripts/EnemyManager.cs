using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    //[SerializeField] Transform target;
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] Slider enemyHPSlider;
    [SerializeField] GameObject dropItem;

    private int enemyCurrentHP;
    private int damage;

    private Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private float speed = 2.0f;
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        //初期HPのセット
        enemyCurrentHP = enemyStatusSO.enemyStatusList[0].HP;
        enemyHPSlider.maxValue = enemyStatusSO.enemyStatusList[0].HP;
        enemyHPSlider.value = enemyCurrentHP;

        target = GameObject.Find("Main Camera").GetComponent<Transform>();
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
        target = GameObject.Find("Main Camera").GetComponent<Transform>();
        Vector3 betweenPtoE = target.position;
        betweenPtoE.z += 0.5f;

        agent.destination = betweenPtoE;


        //Vector3 betweenPtoE = agent.destination.position;
        //betweenPtoE.z -= 1f;
        //agent.destination.position = betweenPtoE;

        if (distance >= 0 && distance < 2)
        {
            animator.SetBool("Attack", true);
        }

        if (distance >= 2)
        {
            animator.SetBool("Attack", false);
        }

    }

    Transform Des(Transform pos)
    {
        Vector3 betweenPtoE = pos.position;
        betweenPtoE.z -= 1f;
        pos.position = betweenPtoE;

        return pos.transform;
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
                enemyCurrentHP -= damage;
                enemyHPSlider.value = enemyCurrentHP;
            }

            if (enemyCurrentHP <= 0)
            {
                animator.SetBool("Death", true);

                //アイテムの座標を調節してドロップさせる
                dropItem.transform.position = this.transform.position;
                Vector3 height = dropItem.transform.position;
                height.y = 0.3f;
                dropItem.transform.position = height;
                Invoke("SetActive", 5);

                //Enemyを破壊
                Destroy(this.gameObject, 5.0f);
            }

            Debug.Log(enemyCurrentHP);
        }
    }

    void SetActive()
    {
        dropItem.SetActive(true);
    }
}
