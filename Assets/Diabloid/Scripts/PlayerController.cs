using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; // Синглтон для PlayerController

    private NavMeshAgent agent;
    public Camera mainCamera;
    private Animator animator;

    public float speed = 5f;
    public float sprintSpeed = 10f;
    public float rotationSpeed = 10f; // Скорость поворота

    private bool isMoving = false;

    //public Inventory playerInventory;
    public GameObject dropPoint;
    public float interactionRange = 5f;
    public NavMeshAgent Agent => agent;


    public Vector3 moveDirection { get; private set; } // Добавлено свойство

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMouseInput();
        RotatePlayer();

        // Обновляем направление движения
        moveDirection = agent.velocity.normalized;
    }

    void HandleMouseInput()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var interactable = hit.collider.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    float distance = Vector3.Distance(hit.point, transform.position);
                    if (distance <= interactionRange)
                    {
                        interactable.OnInteract(hit.point);  // Call OnInteract when an interactable is found
                    }
                    else
                    {
                        Debug.Log("You are too far away to interact!");
                    }
                }
                else
                {
                    MoveToTarget(hit.point);
                }
            }
        }
    }

    private IInteractable currentInteractable;

    // Call this method when the player interacts with something (like pressing a key or button)
    public void InteractWithUI(IInteractable interactable)
    {
        if (interactable != null)
        {
            interactable.Interact(); // Perform the interaction
        }
    }

    void MoveToTarget(Vector3 target, System.Action onArrive = null)
    {
        if (agent == null) return;

        agent.SetDestination(target);
        isMoving = true;

        agent.speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        StartCoroutine(WaitForArrival(onArrive));
    }

    System.Collections.IEnumerator WaitForArrival(System.Action onArrive)
    {
        while (isMoving)
        {
            if (agent != null && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                isMoving = false;
                onArrive?.Invoke();
            }
            yield return null;
        }
    }

    void RotatePlayer()
    {
        if (isMoving)
        {
            Vector3 direction = agent.steeringTarget - transform.position;
            if (direction.sqrMagnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
