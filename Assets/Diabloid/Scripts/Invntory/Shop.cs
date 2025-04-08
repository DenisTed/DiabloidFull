using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Inventory playerInventory; // �������� ������
    public int salePrice = 10; // ֳ�� ������� ��������

    public TextMeshProUGUI coinText; // ����� ��� �����
    private int coins = 0; // ���������� ������ �����

    void OnMouseDown()
    {
        // ���� �������� ��� ��������, ������� ��������
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) <= PlayerController.instance.interactionRange)
        {
            SellItems();
        }
        else
        {
            Debug.Log("You are too far from the shop!");
        }
    }

    void SellItems()
    {
        if (playerInventory.items.Count > 0)
        {
            // ������� ������ ������� �� ���������
            Item itemToSell = playerInventory.items[0]; // ���������, ������� ������ �������
            playerInventory.RemoveItem(itemToSell); // ��������� ������� � ���������

            // ������ ������ �������� �� ���� ��������
            coins += itemToSell.salePrice;

            // ��������� ����� �����
            UpdateCoinText();

            Debug.Log($"Sold {itemToSell.itemName}. Coins: {coins}");
        }
        else
        {
            Debug.Log("No items to sell!");
        }
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + coins;
    }

    // ��������� ������ ���������� IInteractable
    public void OnInteract(Vector3 hitPoint)
    {
        if (Vector3.Distance(hitPoint, transform.position) <= PlayerController.instance.interactionRange)
        {
            SellItems();
        }
    }
}
