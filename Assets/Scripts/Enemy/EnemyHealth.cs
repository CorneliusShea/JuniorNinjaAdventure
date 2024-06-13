using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamagable
{
    [SerializeField] float health;


    Animator anim;
    EnemyBrain brain;
    EnemySelector selector;
    EnemyLoot enemyLoot;

    Rigidbody2D rb;

    public float CurrentHealth { get; private set; }

    public static event Action OnEnemyDead;


    void Awake()
    {
        anim = GetComponent<Animator>();
        brain = GetComponent<EnemyBrain>();
        selector = GetComponent<EnemySelector>();
        enemyLoot = GetComponent<EnemyLoot>();

        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CurrentHealth = health;
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0f)
        {
            DisableEnemy();
            QuestManager.i.AddProgress("Kill2Enemies", 1);
        }
        else
        {
            DamageManager.i.ShowDamageText(amount, transform);
        }

    }

    public void DisableEnemy()
    {
        anim.SetTrigger("gotKilled");
        brain.enabled = false;
        selector.DeactivateSelector();
        rb.bodyType = RigidbodyType2D.Static;
        OnEnemyDead?.Invoke();
        GameManager.i.AddPlayerXP(enemyLoot.XPDropped);


    }


}
