using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IInteractable.cs
// IInteractable.cs
public interface IInteractable
{
    void Interact();
    void OnInteract(Vector3 position); // Ensure the OnInteract method signature is correct
}

