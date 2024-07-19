using System;
using UnityEngine;
using UnityEngine.Serialization;

public class WalkState : MonoBehaviour
{
    [FormerlySerializedAs("blue")] public Enemy enemy;
    
    public void StartWalking()
    { 
        enemy = GetComponent<Enemy>();
        enemy.animator.SetBool("isPatrolling", true);
        Vector3 direction = (enemy.playerTransform.position - enemy.transform.position).normalized;
        enemy.transform.position += direction * enemy.speed * Time.deltaTime;
        enemy.transform.LookAt(enemy.playerTransform);
    }

    private void OnDisable()
    {
        enemy.animator.SetBool("isPatrolling", false);
    }
}

