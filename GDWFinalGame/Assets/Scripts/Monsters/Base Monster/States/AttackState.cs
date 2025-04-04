using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : MonsterState
{
    private Monster monster;
    private float weight;
    private float attackRange;//distance the player has to be to attack the player
    private string animName;
    private bool inAnim;
    public AttackState(string animName, Monster monster, float weight, float attackRange)
    {
        this.animName = animName;
        this.monster = monster;
        this.weight = weight;
        this.attackRange = attackRange;

    }
    
    //runs when the state is first set
    public void EnterState()
    {
        inAnim = true;
        monster.GetAnimator().SetBool(animName, inAnim);
    } 
    
    //performs the action of the state
    public void ExecuteState()
    {
        monster.CancelMonsterDestination();
        monster.SpawnAttackBox();
        
    }
    
    //runs when the state is over
    public void ExitState()
    {
        inAnim = false;
        monster.SetAnimation(animName, inAnim);
    }
    
    
    //gets the weight of the task as well as conditions can go here for realistic like behaviour
    public float GetWeight()
    {
        if (monster.GetCanSeePlayer() == true && monster.GetDistanceFromPlayer() < attackRange)
            return weight;
        else
            return 0;
    }
}
