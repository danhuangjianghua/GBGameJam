using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void addItem(Item item)
    {
        items.Add(item);
    }

    public void deleteItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            return;
        }
        Debug.LogWarning($"����������{item}���޷�ɾ��");
    }
}
