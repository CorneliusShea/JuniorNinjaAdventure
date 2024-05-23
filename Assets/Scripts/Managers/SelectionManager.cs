using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] LayerMask enemyMask;

    Camera mainCamera;

    public static event Action<EnemyBrain> OnEnemySelect;
    public static event Action OnNoSelection;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        SelectEnemy();
    }

    void SelectEnemy()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCamera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, enemyMask);

            if(hit.collider != null)
            {
                //EnemyBrain enemy = hit.collider.GetComponent<EnemyBrain>();

                
                   if (hit.collider.TryGetComponent(out EnemyBrain enemy))
                    {
                    if (enemy.GetComponent<EnemyHealth>().CurrentHealth <= 0f) 
                    {
                        EnemyLoot enemyLoot = enemy.GetComponent<EnemyLoot>(); 
                        LootManager.i.ShowLoot(enemyLoot);                   
                    }
                    else
                    {
                        // Select the enemy
                        OnEnemySelect?.Invoke(enemy);  
                    }

                }

            }
            else
            {
                OnNoSelection?.Invoke();
            }

        }
    }
}
