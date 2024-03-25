using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;

    //this is called hashing a value
    readonly int moveX = Animator.StringToHash("moveX");
    readonly int moveY = Animator.StringToHash("moveY");
    readonly int isMoving = Animator.StringToHash("isMoving");
    readonly int gotKilled = Animator.StringToHash("gotKilled");
    readonly int revived = Animator.StringToHash("revived");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void HandleDeadAnimation()
    {
        anim.SetTrigger(gotKilled);
        
    }

    public void HandleMoveAnimationBool(bool value)
    {
        anim.SetBool(isMoving, value);

    }

    public void HandleMovingAnimation(Vector2 direction)
    {
        anim.SetFloat(moveX, direction.x);
        anim.SetFloat(moveY, direction.y);
    }

    public void HandleReviveAnimation()
    {
        anim.SetTrigger(revived);
        HandleMovingAnimation(Vector2.down);
    }
}
