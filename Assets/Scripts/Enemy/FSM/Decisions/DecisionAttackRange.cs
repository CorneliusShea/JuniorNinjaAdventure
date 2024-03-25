using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionAttackRange : FSM_Decision
{
    [SerializeField] float attackRange;
    [SerializeField] LayerMask playerLayer;

    EnemyBrain enemyBrain;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }
    public override bool Decide()
    {

        return InAttackRange();
    }

    private bool InAttackRange()
    {
        if (enemyBrain.Player == null)
            return false;

        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, attackRange, playerLayer);

        if (playerCollider != null)
            return true;

        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
