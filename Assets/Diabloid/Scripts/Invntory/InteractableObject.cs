using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InteractableObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        // Define interaction logic here, e.g., opening a door, picking up an item, etc.
        Debug.Log("Interacted with " + gameObject.name);
    }

    public void OnInteract(Vector3 position)
    {
        // Define additional behavior when interacted with, such as changing the object state
        Debug.Log("Object interacted at position: " + position);
    }
}
