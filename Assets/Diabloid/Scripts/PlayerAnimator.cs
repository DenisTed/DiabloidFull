using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;

    public float runningSpeedThreshold = 3.5f; // Порог скорости для бега

    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = PlayerController.instance;
    }

    void Update()
    {
        if (playerController != null && playerController.Agent != null)
        {
            float speed = playerController.Agent.velocity.magnitude; // Теперь Agent доступен

            bool isRunning = speed >= runningSpeedThreshold;

            Debug.Log($"Speed: {speed}, Is Running: {isRunning}");

            animator.SetBool("isRunning", isRunning);
            animator.SetBool("isWalking", !isRunning && speed > 0);
        }
    }
}
