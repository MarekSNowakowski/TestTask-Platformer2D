using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField]
    private IntVariable maxHealth;

    [SerializeField]
    private EnemyAnimations enemyAnimations;

    private int currentHealth;

    

    private void Start()
    {
        currentHealth = maxHealth.Value;
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void DealDamage(int value)
    {
        currentHealth -= value;

        if(currentHealth <= 0)
        {
            StartDieing();
        }
        else
        {
            enemyAnimations.SetDamagedAnimationTrue();
        }
    }

    private void StartDieing()
    {
        enemyAnimations.SetDieingAnimationTrue();
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
