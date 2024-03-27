using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAttack : FSM_Action
{
    [SerializeField] float damage;
    [SerializeField] float timeBetweenAttacks;

    EnemyBrain brain;
    float attackTimer;

    private void Awake()
    {
        brain = GetComponent<EnemyBrain>();
    }

    private void Start()
    {
        attackTimer = timeBetweenAttacks;
    }
    public override void Act()
    {
        AttackPlayer();
    }

    void AttackPlayer()
    {
        if (brain.Player == null)
            return;

        attackTimer -= Time.deltaTime;

        if(attackTimer <= 0)
        {
            //Attack
            IDamagable player = brain.Player.GetComponent<IDamagable>();
            player.TakeDamage(damage);
            attackTimer = timeBetweenAttacks;
        }
        
    }
}
