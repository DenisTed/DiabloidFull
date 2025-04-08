using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Inventory playerInventory; // Інвентар гравця
    public int salePrice = 10; // Ціна продажу предметів

    public TextMeshProUGUI coinText; // Текст для монет
    private int coins = 0; // Початковий баланс монет

    void OnMouseDown()
    {
        // Якщо персонаж біля магазину, продаємо предмети
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
            // Продаємо перший предмет із інвентаря
            Item itemToSell = playerInventory.items[0]; // Наприклад, продаємо перший предмет
            playerInventory.RemoveItem(itemToSell); // Видаляємо предмет з інвентаря

            // Додаємо монети відповідно до ціни предмета
            coins += itemToSell.salePrice;

            // Оновлюємо текст монет
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

    // Реалізація методу інтерфейсу IInteractable
    public void OnInteract(Vector3 hitPoint)
    {
        if (Vector3.Distance(hitPoint, transform.position) <= PlayerController.instance.interactionRange)
        {
            SellItems();
        }
    }
}
