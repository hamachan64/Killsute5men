using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    //“GƒvƒŒƒnƒu
    public GameObject zombiePrefab;
    public GameObject minotaurPrefab;
    public GameObject bossPrefab;

    void Start()
    {
        StartCoroutine("EnemyGenerator");
    }


    IEnumerator EnemyGenerator()
    {
        //5•b‚²‚Æ‚É“G‚ğ¶¬
        for (int i = 0; i < 5; i++)
        {
            GameObject enemy = Instantiate(zombiePrefab);
            enemy.transform.position = new Vector3(i, 0, 20);
            yield return new WaitForSeconds(5);
        }

        yield return new WaitForSeconds(30);

        GameObject minotaur1 = Instantiate(minotaurPrefab);
        GameObject minotaur2 = Instantiate(minotaurPrefab);
        minotaur1.transform.position = new Vector3(-5, 0, 20);
        minotaur2.transform.position = new Vector3(5, 0, 20);

        yield return new WaitForSeconds(30);

        GameObject boss = Instantiate(minotaurPrefab);
        boss.transform.position = new Vector3(0, 0, 20);

    }
}
