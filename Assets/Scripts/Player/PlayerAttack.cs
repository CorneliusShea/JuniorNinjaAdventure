using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    private PlayerActions actions;
    private PlayerAnimations playerAnim;
    private EnemyBrain target;
    private Coroutine attackCoroutine;

    [SerializeField] Weapon initialWeapon;
    [SerializeField] Transform[] attackPositions;

    private Transform currentAttackPosition;
    private float currentAttackRotation;

    private PlayerMovement playerMovement;
    private PlayerMana playerMana;

    


    private void Awake()
    {
        actions = new PlayerActions();
        playerAnim = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        print("Start");
        actions.NewAttack.NewClick.performed += ctx => Attack();
        SelectionManager.OnEnemySelect += SetCurrentEnemy;
        SelectionManager.OnNoSelection += ResetCurrentEnemy;
        EnemyHealth.OnEnemyDead += KilledEnemy;

    }

    private void Update()
    {
        GetFirePosition();
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
        if (currentAttackPosition == null || playerMana.CurrentMana < initialWeapon.RequiredMana)
            yield break;


        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAttackRotation));
        Projectile projectile = Instantiate(initialWeapon.ProjectilePrefab,
                                            currentAttackPosition.position, rotation);

        playerMana.UseMana(initialWeapon.RequiredMana);
        projectile.Direction = Vector3.up;

        projectile.Damage = initialWeapon.Damage;

        playerAnim.HandleAttackAnimation(true);
        yield return new WaitForSeconds(0.25f);
        playerAnim.HandleAttackAnimation(false);

    }

    private void GetFirePosition()
    {
        Vector2 moveDirection = playerMovement.MoveDirection;

        if (moveDirection.x > 0f)
        {
            currentAttackPosition = attackPositions[1]; //RIGHT
            currentAttackRotation = -90f;
        }
        else if (moveDirection.x < 0f)
        {
            currentAttackPosition = attackPositions[3]; //LEFT
            currentAttackRotation = -270f;
        }

        if (moveDirection.y > 0f)
        {
            currentAttackPosition = attackPositions[0]; //UP
            currentAttackRotation = 0f;
        }
        else if (moveDirection.y < 0f)
        {
            currentAttackPosition = attackPositions[2]; //DOWN
            currentAttackRotation = -180f;
        }
    }

    private void KilledEnemy()
    {
        target = null;
    }


}
