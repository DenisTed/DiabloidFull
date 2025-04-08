using UnityEngine;

public class DiabloCameraController : MonoBehaviour
{
    public Transform target; // Посилання на персонажа
    public float distance = 10f; // Відстань камери від персонажа
    public float height = 5f; // Висота камери над персонажем
    public float rotationSpeed = 5f; // Швидкість обертання камери
    public float moveSpeed = 5f; // Швидкість переміщення персонажа

    private Vector3 offset;
    private float currentRotationY = 0f;

    void Start()
    {
        offset = new Vector3(0, height, -distance);
    }

    void Update()
    {
        HandleCameraRotation();
        FollowTarget();
    }

    void HandleCameraRotation()
    {
        if (Input.GetMouseButton(2)) // Середня кнопка миші
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
            offset = Quaternion.Euler(0, rotationX, 0) * offset;
        }

        if (Input.GetMouseButton(1)) // Права кнопка миші
        {
            float rotationY = Input.GetAxis("Mouse X") * rotationSpeed;
            currentRotationY += rotationY;
            Quaternion rotation = Quaternion.Euler(0, currentRotationY, 0);
            offset = rotation * new Vector3(0, height, -distance);
        }
    }

    void FollowTarget()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.LookAt(target.position);
        }
    }
}
