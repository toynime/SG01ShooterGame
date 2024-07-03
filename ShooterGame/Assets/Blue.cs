using UnityEngine;

public class Blue : MonoBehaviour
{
    public Animator animator;
    public Transform playerTransform;

    private IdleState idleState;
    private WalkState walkState;

    void Start()
    {
        idleState = gameObject.AddComponent<IdleState>();
        walkState = gameObject.AddComponent<WalkState>();
        animator = GetComponent<Animator>();

        idleState.blue = this;
        walkState.blue = this;

        // Find the player GameObject by tag (you need to tag your player GameObject as "Player" in the Inspector)
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("Player GameObject not found! Make sure to tag your player GameObject as 'Player'.");
        }

        StartIdling();
    }

    public void StartIdling()
    {
        if (animator != null)
            animator.Play("IdleAnimation");
        else
        {
            Debug.LogError("Animator not assigned to Blue script in StartIdling!");
            return;
        }

        idleState.enabled = true;
        walkState.enabled = false;
    }

    public void StartWalking()
    {
        if (animator != null)
            animator.Play("WalkAnimation");
        else
        {
            Debug.LogError("Animator not assigned to Blue script in StartWalking!");
            return;
        }

        idleState.enabled = false;
        walkState.enabled = true;
    }
}