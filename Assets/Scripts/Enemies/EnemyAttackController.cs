using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyAttackController : MonoBehaviour
{
    [SerializeField]
    private ObservableIntVariable playerCurrentHealth;

    private readonly string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PLAYER_TAG))
        {
            playerCurrentHealth.Value--;
        }
    }
}
