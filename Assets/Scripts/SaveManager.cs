using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void SaveGame()
    {
        //PlayerPrefs.SetFloat("xPos", player.transform.position.x);
        //PlayerPrefs.SetFloat("yPos", player.transform.position.y);
        //PlayerPrefs.SetFloat("zPos", player.transform.position.z);

        PlayerPrefs.SetInt("currentHP", player.GetComponent<PlayerController>().currentHP);
        PlayerPrefs.Save();
    }

    public void LoadGame() 
    {
        //player.transform.position = new Vector3(PlayerPrefs.GetFloat("xPos", 0), PlayerPrefs.GetFloat("yPos", 0), PlayerPrefs.GetFloat("zPos", 0));
        
        player.GetComponent<PlayerController>().currentHP = PlayerPrefs.GetInt("currentHP", 0);
    }

}
