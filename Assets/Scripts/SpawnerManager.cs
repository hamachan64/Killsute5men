using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    //“GƒvƒŒƒnƒu
    public GameObject enemyPrefab;

    void Start()
    {
        StartCoroutine("EnemyGenerator");
    }


    IEnumerator EnemyGenerator()
    {
        //•b‚²‚Æ‚É“G‚ğ¶¬
        for (int i = 0; i < 3; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = new Vector3(i, 0, 20);
            yield return new WaitForSeconds(5);
        }
    }
}
