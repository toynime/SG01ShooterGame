using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator; // Ensure this is assigned in Unity Inspector
    public Transform playerTransform;

    private IdleState idleState;
    private WalkState walkState;
    public float speed = 2.0f;
    [SerializeField] private int maxHealth = 10;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        // Check if animator is assigned in the Inspector
        if (animator == null)
        {
            Debug.LogError("Animator not assigned to Blue script in Start!");
            // Attempt to find the Animator component on the same GameObject
            animator = GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("Animator component not found on the GameObject!");
                return; // Exit the Start() method if animator is not assigned
            }
        }

        // Add IdleState and WalkState components
        idleState = gameObject.AddComponent<IdleState>();
        walkState = gameObject.AddComponent<WalkState>();
        // Assign references to idleState and walkState
        idleState.enemy = this;
        walkState.enemy = this;

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
        idleState.StartIdling();
    }

    public void StartWalking()
    {
        walkState.StartWalking();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print("Current Health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die(){
    print("Enemy Died");
    }
}
