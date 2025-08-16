using UnityEngine;
using System;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<AllItems.Item> slots = new List<AllItems.Item>();

    public AllItems allItemsInfo;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }


    public void OrganizeItems()
    {
        
    }

    public void SetItem(int id)
    {
        slots.Add(allItemsInfo.GetItemInfo(id));
    }

    public void SaveItemToInventory(int id)
    {
        OrganizeItems();
        SetItem(id);
    }

}
