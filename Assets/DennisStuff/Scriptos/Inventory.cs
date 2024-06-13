using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> itemList = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            ClearInventory();
        }
    }


    public void AddItem(string itemToAdd)
    {
        foreach (string item in itemList)
        {
            if (item == itemToAdd)
                return;
        }

        itemList.Add(itemToAdd);
    }

    public void RemoveItem(string itemToRemove)
    {
        foreach (string item in itemList)
        {
            if (item == itemToRemove)
                itemList.Remove(item);
        }
    }

    public bool CheckForItem(string itemToCheck)
    {
        foreach (string item in itemList)
        {
            if (item == itemToCheck)
                return true;
        }

        return false;
    }

    private void ClearInventory()
    {
        foreach (string item in itemList)
        {
            itemList.Remove(item);
        }
    }


}
