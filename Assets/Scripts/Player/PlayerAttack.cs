using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerActions actions;
    private PlayerAnimations playerAnim;
    private EnemyBrain target;
    private Coroutine attackCoroutine;

    private void Awake()
    {
        actions = new PlayerActions();
        playerAnim = new PlayerAnimations();
    }

    private void Start()
    {
        print("Start");
        //actions.Attack.ExecuteAttack.performed += ctx => Attack();
        actions.NewAttack.NewClick.performed += ctx => Attack();
        SelectionManager.OnEnemySelect += SetCurrentEnemy;
        SelectionManager.OnNoSelection += ResetCurrentEnemy;

    }

    void SetCurrentEnemy(EnemyBrain eTarget)
    {
        target = eTarget;
    }

    void ResetCurrentEnemy()
    {
        target = null;
    }

    void Attack()
    {
        print("Attack");
        if (target == null) return;
        print("Attacked");
        if (attackCoroutine != null)
            StopCoroutine(attackCoroutine);

        attackCoroutine = StartCoroutine(AttackCo());

    }

    IEnumerator AttackCo()
    {
        print("Coroutine");
        playerAnim.HandleAttackAnimation(true);
        yield return new WaitForSeconds(0.5f);
        playerAnim.HandleAttackAnimation(false);
    }

}
