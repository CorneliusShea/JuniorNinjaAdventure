using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    [SerializeField] GameObject selectorSprite;

    EnemyBrain brain;

    private void Awake()
    {
        brain = GetComponent<EnemyBrain>();
    }

    private void Start()
    {
        SelectionManager.OnEnemySelect += ActivateSelector;
        SelectionManager.OnNoSelection += DeactivateSelector;
    }

    void ActivateSelector(EnemyBrain enemyBrain)
    {
        if(brain == enemyBrain)
            selectorSprite.SetActive(true);

    }

    void DeactivateSelector()
    {
        selectorSprite.SetActive(false);
    }
}
