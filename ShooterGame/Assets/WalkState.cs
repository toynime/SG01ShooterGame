using UnityEngine;

public class WalkState : MonoBehaviour
{
    public Blue blue;
    public float speed = 2.0f;

    void Start()
    {
        if (blue.animator != null)
            blue.animator.Play("WalkAnimation");
        else
            Debug.LogError("Animator not assigned to Blue script in WalkState!");
    }

    void Update()
    {
        if (blue.playerTransform == null)
        {
            Debug.LogWarning("Player Transform not assigned to Blue script in WalkState!");
            return;
        }

        float distance = Vector3.Distance(blue.transform.position, blue.playerTransform.position);

        if (distance < 5.0f)
        {
            Vector3 direction = (blue.playerTransform.position - blue.transform.position).normalized;
            blue.transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            blue.StartIdling();
        }
    }
}

