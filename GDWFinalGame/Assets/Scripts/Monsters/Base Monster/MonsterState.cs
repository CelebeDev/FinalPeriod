using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An interface which holds the outline os each part of the state
/// </summary>
public interface MonsterState
{
    //runs when the state is first set
    void EnterState(); 
    //performs the action of the state
    void ExecuteState();
    //runs when the state is over
    void ExitState();
    //gets the weight of the task as well as holds the conditions for the states
    float GetWeight();
}
