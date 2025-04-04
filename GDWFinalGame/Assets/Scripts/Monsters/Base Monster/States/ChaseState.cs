using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonsterState
{
    Monster monster;
    private float monsterSpeed;
    private float weight = 3;
    private bool inAnim;
    string animName;

    public ChaseState(string animName, Monster monster,float weight ,float monsterSpeed)
    {
        this.animName = animName;
        this.monster = monster;
        this.weight = weight;
        this.monsterSpeed = monsterSpeed;
    }
    
    public void EnterState()
    {
        inAnim = true;
        monster.GetAnimator().SetBool(animName, inAnim);
        monster.SetMonsterSpeed(monsterSpeed * 2);
    }
    
    public void ExecuteState()
    {
        monster.CancelMonsterDestination();

        //set the monsters new destination towards the player
        monster.SetMonsterDestination(monster.GetPlayer().position);
    }
    
    public void ExitState()
    {
        monster.SetMonsterSpeed(monsterSpeed);
        inAnim = false;
        monster.SetAnimation(animName, inAnim);
    }

    public float GetWeight()
    {
        if (monster.GetCanSeePlayer() == true)
            return weight;
        else
            return 0;
    }
}
