using UnityEngine;
using UnityEngine.UI;

public class InteractableUI : MonoBehaviour, IInteractable  // Implementing IInteractable interface
{
    public Button button; // Reference to the UI button

    private void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(OnClick); // Set up the button click listener
        }
    }

    // Implement the Interact method from the IInteractable interface
    public void Interact()
    {
        // Custom interaction logic
        Debug.Log("UI Element Interacted!");
        // Additional logic can be added here, like triggering an animation or event
    }

    // Implement the OnInteract method from the IInteractable interface
    public void OnInteract(Vector3 position)
    {
        // Handle interaction logic when a UI element is interacted with
        Debug.Log("UI Element interacted at position: " + position);
        // You can define specific logic that uses the position, such as triggering animations
    }

    // This method will be called when the button is clicked
    private void OnClick()
    {
        Interact(); // Calls the Interact method when the button is clicked
    }
}
