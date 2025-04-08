using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask groundLayer; // Шар землі для визначення точки кліку
    private NavMeshAgent agent; // NavMeshAgent для навігації

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (!agent.isOnNavMesh)
        {
            Debug.LogError("Player is not on a NavMesh!");
        }

        // Налаштування для 2D
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        // Перевіряємо клік миші
        if (Input.GetMouseButtonDown(0))
        {
            MoveToMouseClick();
        }
    }

    void MoveToMouseClick()
    {
        // Отримуємо координати кліку
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

        // Промінь у 2D координатах
        RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero, Mathf.Infinity, groundLayer);

        if (hit.collider != null)
        {
            // Встановлюємо нову ціль для NavMeshAgent
            agent.SetDestination(hit.point);
        }
    }
}
