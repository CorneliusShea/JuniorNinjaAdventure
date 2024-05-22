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
    [SerializeField] public PlayerStats playerStats;

    [SerializeField] Weapon initialWeapon;
    [SerializeField] Transform[] attackPositions;

    private Transform currentAttackPosition;
    private float currentAttackRotation;

    private PlayerMovement playerMovement;
    private PlayerMana playerMana;

    [SerializeField] ParticleSystem slashFX;
    [SerializeField] float attackRange;
    public Weapon CurrentWeapon { get; set; }


    private void Awake()
    {
        actions = new PlayerActions();
        playerAnim = GetComponent<PlayerAnimations>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        WeaponManager.i.EquipWeapon(initialWeapon);

        CurrentWeapon = initialWeapon;
        actions.Attack.ExecuteAttack.performed += ctx => Attack();
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
        if (currentAttackPosition == null)
            yield break;

        if (CurrentWeapon.WeaponType == WeaponType.MAGIC)
        {
            if (playerMana.CurrentMana < CurrentWeapon.RequiredMana)
                yield break;
            MagicAttack();
        }
        else
        {
            MeleeAttack();
        }




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

    void MeleeAttack()
    {
        slashFX.transform.position = currentAttackPosition.position;
        slashFX.Play();

        var distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

        if (distanceToTarget <= attackRange)
            target.GetComponent<IDamagable>()?.TakeDamage(GetAttackDamage());

    }

    void MagicAttack()
    {
        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, currentAttackRotation));
        Projectile projectile = Instantiate(CurrentWeapon.ProjectilePrefab,
                                            currentAttackPosition.position, rotation);

        playerMana.UseMana(CurrentWeapon.RequiredMana);
        projectile.Direction = Vector3.up;

        projectile.Damage = GetAttackDamage();
    }

    float GetAttackDamage()
    {
        var damage = playerStats.BaseDamage;
        damage += CurrentWeapon.Damage;

        var critChance = Random.Range(0, 100);
        if (critChance <= playerStats.CriticalChance)
            damage += damage * (playerStats.CriticalDamage / 100);

        return damage;
    }

    public void EquipWeapon(Weapon newWeapon)
    {
        CurrentWeapon = newWeapon;
        playerStats.TotalDamage = playerStats.BaseDamage + CurrentWeapon.Damage;

    }


    private void KilledEnemy()
    {
        target = null;
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
