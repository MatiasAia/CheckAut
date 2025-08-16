using UnityEngine;
using System;

[CreateAssetMenu(fileName = "AllItems", menuName = "Scriptable Objects/AllItems")]
public class AllItems : ScriptableObject
{
    public Item[] itemsInfo;

    public Item GetItemInfo(int id)
    {
        for (int i = 0; i < itemsInfo.Length; i++)
            if (id == itemsInfo[i].id)
                return itemsInfo[i];

        return null;
    }


    [System.Serializable]
    public class Item
    {
        public int id;
        public string name;
        public Sprite sprite;
    }

    
}
