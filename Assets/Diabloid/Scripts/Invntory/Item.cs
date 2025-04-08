using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public string itemName;
    public Sprite icon;
    public GameObject itemPrefab;
    public int salePrice = 10; // Додаємо поле для ціни продажу

    public Inventory playerInventory;  // Зазначимо інвентар для додавання предметів

    void OnMouseDown()
    {
        // Перевіримо, чи є відстань до персонажа, і чи можемо взаємодіяти
        float distance = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
        if (distance <= PlayerController.instance.interactionRange)
        {
            // Додаємо предмет в інвентар
            playerInventory.AddItem(this);
            // Деактивуємо предмет у світі, оскільки він переміщений в інвентар
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("You are too far from the item!");
        }
    }
}
