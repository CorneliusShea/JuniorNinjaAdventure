using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionDetectPlayer : FSM_Decision
{
    [SerializeField] float aggroRange;
    [SerializeField] LayerMask playerLayer;

    EnemyBrain enemyBrain;

    private void Awake()
    {
        enemyBrain = GetComponent<EnemyBrain>();
    }
    public override bool Decide()
    {

        return DetectPlayer();
    }

    bool DetectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, aggroRange, playerLayer);

        // Hit something
        if(playerCollider != null )
        {
            enemyBrain.Player = playerCollider.transform;
            return true;
        }

        enemyBrain.Player = null;
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
