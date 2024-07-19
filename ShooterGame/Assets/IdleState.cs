using System;
using UnityEngine;
using UnityEngine.Serialization;

public class IdleState : MonoBehaviour
{
    [FormerlySerializedAs("blue")] public Enemy enemy;
    private bool isNear=false;
    [SerializeField] private float _attackDistance = 5f;
    [SerializeField] private float _followDistance = 8.0f;
    void Update()
    {
        float distance = Vector3.Distance(enemy.transform.position, enemy.playerTransform.position);
        if (distance < _followDistance) isNear = true;
        if (!isNear) return;
        enemy.StartWalking();
        enemy.animator.SetBool("Attack", distance <= _attackDistance);

    }

    public void StartIdling()
    {
        enemy = GetComponent<Enemy>();
        enemy.animator.SetBool("isPatrolling", false);

    }
    
}

