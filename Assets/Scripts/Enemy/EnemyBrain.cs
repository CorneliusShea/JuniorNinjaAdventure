using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] EnemyStateID enemyStateID;
    [SerializeField] FSM_State[] states;

    public FSM_State CurrentState { get; set; }

    private void Start()
    {
        ChangeState(enemyStateID);
    }

    private void Update()
    {
        UpdateState();
    }

    public void UpdateState()
    {
        CurrentState.ExecuteActions();
        CurrentState.ExecuteTransitions();
    }


    FSM_State GetState(EnemyStateID enemyStateID)
    {
        for(int i = 0; i < states.Length; i++)
        {
            if (states[i].EnemyStateID == enemyStateID)
            {
                return states[i];
            }
        }
        return null;
    }

    public void ChangeState(EnemyStateID newStateID)
    {
        var newState = GetState(newStateID);

        if (newState == null)
            return;

        CurrentState = newState;
    }
}
