using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    PlayerAnimations playerAnimations;
    PlayerMana playerMana;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
        playerMana = GetComponent<PlayerMana>();
    }

    public PlayerStats PlayerStats => playerStats;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (playerStats.CurrentHealth <= 0)
                PlayerReset();
            
        }
    }

    public void PlayerReset()
    {
        playerStats.ResetPlayer();
        playerAnimations.HandleMovingAnimation(Vector2.down);
        playerMana.ResetMana();
    }
}
