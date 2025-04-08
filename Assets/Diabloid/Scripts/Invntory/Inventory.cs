using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();  // ������ ��� ���������� ��������

    // ����� ��� ��������� �������� � ��������
    public void AddItem(Item item)
    {
        if (item != null)
        {
            items.Add(item);
            Debug.Log($"Item {item.itemName} added to inventory.");
        }
        else
        {
            Debug.Log("Cannot add a null item.");
        }
    }

    // ����� ��� ��������� �������� � ���������
    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Item {item.itemName} removed from inventory.");
        }
    }
}
