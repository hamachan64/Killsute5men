using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    //敵プレハブ
    public GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine("EnemyGenerator");
    }


    IEnumerator EnemyGenerator()
    {
        //秒ごとに敵を生成
        for (int i = 0; i < 3; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(i, 0, 20);
            yield return new WaitForSeconds(5);
        }
    }
}
