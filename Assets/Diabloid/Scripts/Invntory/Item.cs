using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public string itemName;
    public Sprite icon;
    public GameObject itemPrefab;
    public int salePrice = 10; // ������ ���� ��� ���� �������

    public Inventory playerInventory;  // ��������� �������� ��� ��������� ��������

    void OnMouseDown()
    {
        // ���������, �� � ������� �� ���������, � �� ������ ���������
        float distance = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
        if (distance <= PlayerController.instance.interactionRange)
        {
            // ������ ������� � ��������
            playerInventory.AddItem(this);
            // ���������� ������� � ���, ������� �� ���������� � ��������
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("You are too far from the item!");
        }
    }
}
