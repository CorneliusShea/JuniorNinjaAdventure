using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyStateID
{
    NONE,WANDER,PATROL,CHASE,ATTACK
}

[System.Serializable]
public class FSM_State
{
    public EnemyStateID enemyStateID;
    public FSM_Action[] Actions;
    public FSM_Transition[] Transitions;
    

    public void UpdateState(EnemyBrain brain)
    {
        ExecuteActions();
        ExecuteTransitions(brain);
    }

    public void ExecuteActions()
    {
        for (int i = 0; i < Actions.Length; i++)
        {
            Actions[i].Act();
        }
    }

    public void ExecuteTransitions(EnemyBrain brain)
    {
        if(Transitions == null || Transitions.Length == 0)
            return;
        
        for (int i = 0; i < Transitions.Length; i++)
        {
           bool value = Transitions[i].Decision.Decide();

            if ( value)
            {
                //execute true state
                brain.ChangeState(Transitions[i].TrueState);
            }
            else
            {
                //execute false state
                brain.ChangeState(Transitions[i].FalseState);
            }
            
        }
    }
}
