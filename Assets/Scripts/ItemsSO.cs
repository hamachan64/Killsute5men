using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemsSO : ScriptableObject
{
    public List<Items> itemList = new List<Items>();

    [System.Serializable]
    public class Items
    {
        [SerializeField] itemType type;
        [SerializeField] string itemName;
        //[SerializeField] int itemNum;
        [TextArea]
        [SerializeField] string itemDescription;

        public enum itemType
        {
            coin,
            weapon,
            tool,

        }

        public string ItemName { get => itemName; }
        //public int ItemNum { get => itemNum; }
    }
}