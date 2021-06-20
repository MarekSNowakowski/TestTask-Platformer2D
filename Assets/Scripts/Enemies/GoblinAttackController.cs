using UnityEngine;

public class GoblinAttackController : EnemyAttackController
{
    [SerializeField]
    EnemyAnimations enemyAnimations;

    protected override void HandlePlayerHit()
    {
        base.HandlePlayerHit();
        enemyAnimations.SetAttackingAnimationTrue();
    }
}
