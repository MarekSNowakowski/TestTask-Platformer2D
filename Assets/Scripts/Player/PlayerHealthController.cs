using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField]
    private ObservableIntVariable playerCurrentHealth;
    [SerializeField]
    private PlayerAnimations playerAnimations;
    [SerializeField]
    private PlayerMovement playerMovement;

    public void OnPlayerDamaged()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (!playerCurrentHealth || !playerAnimations || !playerMovement)
        {
            Debug.LogWarning("Player health controller is missing a reference!");
        }
        else if (playerCurrentHealth.Value <= 0)
        {
            playerAnimations.StartDieAnimation();
            playerMovement.PlayerDead();
        }
        else
        {
            playerAnimations.PlayerDamagedAnimation();
        }
    }

    internal void DamagePlayer(Transform transform, int value)
    {
        throw new NotImplementedException();
    }

    public void DeactivatePlayer()
    {
        gameObject.SetActive(false);
    }
}
