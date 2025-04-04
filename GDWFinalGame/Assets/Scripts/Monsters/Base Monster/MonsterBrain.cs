using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A Finite State Machine(FSM) that controls the monster AI allowing for 
/// </summary>
public class MonsterBrain : MonoBehaviour
{
    List<MonsterState> monsterStates = new List<MonsterState>();

    private MonsterState currentState;
    // Update is called once per frame
    void Update()
    {
        
        SetCurrentState();
    }

    void SetCurrentState()
    {
        MonsterState nextState = null;
        float highestWeight = float.MinValue;
        
        //means the list is empty so return
        if (monsterStates.Count == 0)
            return;

        //compares each state weight and picks the highest weight setting the state
        foreach (MonsterState state in monsterStates)
        {
            float weight = state.GetWeight();
            if (weight > highestWeight)
            {
                highestWeight = weight;
                nextState = state;
            }
        }

        //If there is a state change switch out the monsters current state for the next state
        if (nextState != currentState)
        {
            currentState?.ExitState();
            currentState = nextState;
            currentState.EnterState();
        }
        
        //executes the state
        currentState?.ExecuteState(); 
        
    }
    
    
    //when called adds a state to the monster
    public void AddState(MonsterState state)
    {
        monsterStates.Add(state);
    }
}
