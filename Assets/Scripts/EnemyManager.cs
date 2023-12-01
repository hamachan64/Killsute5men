using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] Slider enemyHPSlider;
    [SerializeField] GameObject dropItem;

    private int enemyCurrentHP;
    private int damage;

    private NavMeshAgent agent;
    private Animator animator;
    private float speed = 2.0f;
    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        //����HP�̃Z�b�g
        enemyCurrentHP = enemyStatusSO.enemyStatusList[0].HP;
        enemyHPSlider.maxValue = enemyStatusSO.enemyStatusList[0].HP;
        enemyHPSlider.value = enemyCurrentHP;

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

    }

    private void OnTriggerEnter(Collider col)
    {
        //����̏Փˌ���
        if (col.gameObject.CompareTag("Weapon"))
        {
            //�_���[�W����
            damage = (int)(playerStatusSO.Attack / 2 - enemyStatusSO.enemyStatusList[0].Defence / 4);

            if (damage > 0)
            {
                enemyCurrentHP -= damage;
                enemyHPSlider.value = enemyCurrentHP;
            }

            if (enemyCurrentHP <= 0)
            {
                animator.SetBool("Death", true);

                //�A�C�e���̍��W�𒲐߂��ăh���b�v������
                dropItem.transform.position = this.transform.position;
                Vector3 height = dropItem.transform.position;
                height.y = 0.3f;
                dropItem.transform.position = height;

                //Enemy��j�󂵃A�C�e�����o��
                Destroy(this.gameObject, 5.0f);
                dropItem.SetActive(true);
            }

            Debug.Log(enemyCurrentHP);
        }
    }
}
