using UnityEngine;

public class DiabloCameraController : MonoBehaviour
{
    public Transform target; // ��������� �� ���������
    public float distance = 10f; // ³������ ������ �� ���������
    public float height = 5f; // ������ ������ ��� ����������
    public float rotationSpeed = 5f; // �������� ��������� ������
    public float moveSpeed = 5f; // �������� ���������� ���������

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
        if (Input.GetMouseButton(2)) // ������� ������ ����
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
            offset = Quaternion.Euler(0, rotationX, 0) * offset;
        }

        if (Input.GetMouseButton(1)) // ����� ������ ����
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
