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
    public EnemyStateID EnemyStateID;
    public FSM_Action[] Actions;
    public FSM_Transition[] Transitions;

    public void ExecuteActions()
    {
        for (int i = 0; i < Actions.Length; i++)
        {
            Actions[i].Act();
        }
    }

    public void ExecuteTransitions()
    {
        if(Transitions == null || Transitions.Length == 0)
            return;
        
        for (int i = 0; i < Transitions.Length; i++)
        {
            /*var value = Transitions[i].Decision.Decide();

            if ( value)
            {
                //execute true state
            }
            else
            {
                //execute false state
            }
            */
        }
    }
}
