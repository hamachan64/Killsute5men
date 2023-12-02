using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    //�G�v���n�u
    public GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine("EnemyGenerator");
    }


    IEnumerator EnemyGenerator()
    {
        //�b���ƂɓG�𐶐�
        for (int i = 0; i < 3; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(i, 0, 20);
            yield return new WaitForSeconds(5);
        }
    }
}
