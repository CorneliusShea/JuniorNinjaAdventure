using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    NONE, WANDER, PATROL, CHASE, ATTACK
}

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] EnemyStateID enemyStateID;
    [SerializeField] FSM_State[] states;

    public FSM_State CurrentState { get; set; }
    public Transform Player { get; set; }

    private void Start()
    {
        ChangeState(enemyStateID);
    }

    private void Update()
    {
        if(CurrentState == null)
        {
            return;
        }

        CurrentState.UpdateState(this);
    }

    public void UpdateState(EnemyBrain brain)
    {
        CurrentState.ExecuteActions();
        CurrentState.ExecuteTransitions(null);
    }


    FSM_State GetState(EnemyStateID enemyStateID)
    {
        for(int i = 0; i < states.Length; i++)
        {
            if (states[i].enemyStateID == enemyStateID)
            {
                return states[i];
            }
        }
        return null;
    }

    public void ChangeState(EnemyStateID newStateID)
    {
        FSM_State newState = GetState(newStateID);

        if (newState == null)
            return;

        CurrentState = newState;
    }

}
