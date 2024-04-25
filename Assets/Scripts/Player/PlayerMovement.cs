using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed;
    [SerializeField] Vector2 movementDirection;
    
    PlayerActions actions;
    PlayerData playerData;
    PlayerAnimations playerAnimations;
    Rigidbody2D rb;

    public Vector2 MoveDirection => movementDirection;



    private void Awake()
    {
        actions = new PlayerActions();
        playerData = GetComponent<PlayerData>();
        playerAnimations = GetComponent<PlayerAnimations>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }



    void ReadMovement()
    {
        movementDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;
        if(movementDirection == Vector2.zero )
        {
            playerAnimations.HandleMoveAnimationBool(false);
            return;
        }

        playerAnimations.HandleMoveAnimationBool(true);
        playerAnimations.HandleMovingAnimation(movementDirection);
    }
    void Move()
    {
        if (playerData.PlayerStats.CurrentHealth <= 0)
            return;

        rb.MovePosition(rb.position + movementDirection * (movementSpeed * Time.fixedDeltaTime));
    }



    private void OnEnable()
    {
        actions.Enable();
    }
    private void OnDisable()
    {
        actions.Disable();
    }

}
