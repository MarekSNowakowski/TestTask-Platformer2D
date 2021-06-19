using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField]
    private PlayerAnimations playerAnimations;
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PolygonCollider2D playerAttackRange;
    [SerializeField]
    private ObservableIntVariable playerAttack;
    [SerializeField]
    private ContactFilter2D enemyContactFilter;
    private List<Collider2D> hitEnemies;

    private readonly string ATTACK_BUTTON = "Attack";

    private void Start()
    {
        hitEnemies = new List<Collider2D>();
    }

    private void Update()
    {
        if(Input.GetButtonDown(ATTACK_BUTTON) && playerMovement.IsPlayerGrounded())
        {
            playerAnimations.SetAttackAnimationTrue();
            playerMovement.OnAttackStart();
            HandleEnemyHit();
        }   
    }

    public void StopAttacking()
    {
        playerAnimations.SetAttackAnimationFalse();
        playerMovement.OnAttackStop();
    }

    public void HandleEnemyHit()
    {
        playerAttackRange.OverlapCollider(enemyContactFilter, hitEnemies);
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHit(enemy);
        }
    }

    private void EnemyHit(Collider2D enemy)
    {
        if (enemy)
        {
            EnemyHealthController enemyHealthController;
            if (enemy.gameObject.TryGetComponent(out enemyHealthController))
            {
                enemyHealthController.DealDamage(playerAttack.Value);
            }
            else
            {
                Debug.LogWarning($"Enemy: '{enemy.name}' does not contain enemyHealth component and can't be damaged!");
            }
        }
    }
}
