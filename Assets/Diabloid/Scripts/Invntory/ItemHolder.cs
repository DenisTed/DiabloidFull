using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    public Item item;  // Reference to the Item
    public Sprite swordIcon;  // Reference to the Sprite for the sword's icon
    public GameObject swordPrefab;  // Reference to the GameObject prefab for the sword

    void Start()
    {
        // Initialize the item manually, using the swordIcon and swordPrefab assigned in the inspector
        //item.Initialize(1, "Sword", swordIcon, swordPrefab);
    }
}
