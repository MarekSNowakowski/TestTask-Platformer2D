using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyAttackController : MonoBehaviour
{
    [SerializeField]
    private ObservableIntVariable playerCurrentHealth;

    private PlayerHealthController playerHealthController;

    [SerializeField]
    private IntVariable enemyAttack;

    private IKnockbackable knockbackableComponent;

    private readonly string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            HandlePlayerHit();

            if( knockbackableComponent != null || collision.TryGetComponent(out knockbackableComponent) )
            {
                ApplyKnockback();
            }
        }
    }

    protected virtual void HandlePlayerHit()
    {
        ApplyDamageToPlayer();
    }

    private void ApplyDamageToPlayer()
    {
        if (playerCurrentHealth && enemyAttack)
        {
            playerCurrentHealth.Value -= enemyAttack.Value;
        }
    }

    private void ApplyKnockback()
    {
        knockbackableComponent.StartKnocback(transform.position);
    }
}
