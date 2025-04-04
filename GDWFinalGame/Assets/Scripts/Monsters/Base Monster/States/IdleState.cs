using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonsterState
{
    private Monster monster;
    private float weight = 1;
    private bool inAnim;
    string animName;
    
    public IdleState(string animName, Monster monster, float weight)
    {
        this.animName = animName;
        this.weight = weight;
        this.monster = monster;
    }

    public void EnterState()
    {
        inAnim = true;
        monster.GetAnimator().SetBool(animName, inAnim);
    }
    
    public void ExecuteState()
    {
        monster.CancelMonsterDestination();
    }
    
    public void ExitState()
    {
        inAnim = false;
        monster.SetAnimation(animName, inAnim);
    }

    public float GetWeight()
    {
        return weight;
    }
}
