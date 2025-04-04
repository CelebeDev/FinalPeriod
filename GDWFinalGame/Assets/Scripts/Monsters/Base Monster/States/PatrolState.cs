using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonsterState
{
    private Monster monster;
    private PatrolRoute route;
    private float patrolDistance;//the distance the player has to be from the monster to patrol
    private float weight = 2;   
    private bool inAnim;
    string animName;



    public PatrolState(string animName, Monster monster,float weight,PatrolRoute route,float patrolDistance)
    {
        this.animName = animName;
        this.monster = monster;
        this.weight = weight;
        this.route = route;
        this.patrolDistance = patrolDistance;

    }
    
    public void EnterState()
    {
        inAnim = true;
        monster.GetAnimator().SetBool(animName, inAnim);
        //Debug.Log("Entering Patrol State");
    }
    
    public void ExecuteState()
    {
        //every frame the patrol goal is up the route checks what waypoint it currently is on
        route.SetMonsterCurrentWayPoint();
        monster.SetMonsterDestination(route.GetCurrentWayPoint());
        //Debug.Log("Performing Patrol Animation");
    }
    
    public void ExitState()
    {
        inAnim = false;
        monster.SetAnimation(animName, inAnim);
        //Debug.Log("Exeting Patrol State");
    }

    public float GetWeight()
    {
        //checks if the player is far enough for the monster to patrols
        if(monster.GetDistanceFromPlayer() > patrolDistance && route.GetCoolDown() != true)
            return weight;
        else
            return 0;

    }
}
