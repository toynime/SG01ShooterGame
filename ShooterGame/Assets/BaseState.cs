using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    protected Animator animator;
    protected Transform playerTransform;
    protected Enemy enemy;

    public virtual void Initialize(Animator anim, Transform player, Enemy enemyObj)
    {
        animator = anim;
        playerTransform = player;
        enemy = enemyObj;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}

