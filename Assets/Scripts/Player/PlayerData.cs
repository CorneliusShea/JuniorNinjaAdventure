using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] Item_HealthPotion healthPotion;

    

    PlayerAnimations playerAnimations;
    PlayerMana playerMana;
    PlayerHealth playerHealth;

    public PlayerStats PlayerStats => playerStats;
    public PlayerHealth PlayerHealth => playerHealth;

    public PlayerMana PlayerMana => playerMana;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMana = GetComponent<PlayerMana>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            var result = healthPotion.UseItem();
            if (result)
            {
                print("Used health potion");
            }
        }
    }

    public void PlayerReset()
    {
        playerStats.ResetPlayer();
        playerAnimations.HandleMovingAnimation(Vector2.down);
        playerMana.ResetMana();
    }
}
