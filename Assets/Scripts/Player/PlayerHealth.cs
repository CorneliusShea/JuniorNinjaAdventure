using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] PlayerStats playerStats;
    PlayerAnimations playerAnimations;



    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    public void TakeDamage(float amount)
    {
        if (playerStats.CurrentHealth <= 0)
            return;

        playerStats.CurrentHealth -= amount;

        DamageManager.i.ShowDamageText(amount, this.transform);

        if (playerStats.CurrentHealth <= 0 ) 
        {
            Die();
        }
    }

    void Die()
    {
        playerAnimations.HandleDeadAnimation();
    }

    public bool CanRestoreHealth()
    {
        return playerStats.CurrentHealth > 0f && playerStats.CurrentHealth < playerStats.MaxHealth;
    }

    public void RestoreHealth(float amount)
    {
        playerStats.CurrentHealth += amount;

        if (playerStats.CurrentHealth >= playerStats.MaxHealth)
        {
            playerStats.CurrentHealth = playerStats.MaxHealth;
        }
    }


}
