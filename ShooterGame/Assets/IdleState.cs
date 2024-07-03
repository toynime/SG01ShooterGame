using UnityEngine;

public class IdleState : MonoBehaviour
{
    public Blue blue;

    void Start()
    {
        if (blue.animator != null)
            blue.animator.Play("IdleAnimation");
        else
            Debug.LogError("Animator not assigned to Blue script in IdleState!");
    }

    void Update()
    {
        if (blue.playerTransform == null)
        {
            Debug.LogWarning("Player Transform not assigned to Blue script in IdleState!");
            return;
        }

        float distance = Vector3.Distance(blue.transform.position, blue.playerTransform.position);

        if (distance < 5.0f) // Adjust the detection range as needed
        {
            blue.StartWalking();
        }
    }
}

