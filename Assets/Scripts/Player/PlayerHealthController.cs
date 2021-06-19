using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField]
    private ObservableIntVariable playerCurrentHealth;
    [SerializeField]
    private PlayerAnimations playerAnimations;

    public void OnPlayerDamaged()
    {
        HandleAnimations();
    }

    private void HandleAnimations()
    {
        if (!playerCurrentHealth || !playerAnimations)
        {
            Debug.LogWarning("Player health controller is missing a reference!");
        }
        else if (playerCurrentHealth.Value <= 0)
        {
            playerAnimations.StartDieAnimation();
        }
        else
        {
            playerAnimations.PlayerDamagedAnimation();
        }
    }

    public void DeactivatePlayer()
    {
        gameObject.SetActive(false);
    }
}
