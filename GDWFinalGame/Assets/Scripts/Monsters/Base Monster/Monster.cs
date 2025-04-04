using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// Packets of data which hold information relating to the monster
/// </summary>
public class Monster : MonoBehaviour
{


    [Header("Monster Componenets")] 
    [SerializeField] float monsterSpeed;
    [SerializeField] private float sightRange;
    [SerializeField] private float attackRange;
    [SerializeField] PatrolRoute route;
    [SerializeField] GameObject attackBox;
    [SerializeField] Transform attackBoxSpawn;
    [SerializeField] AudioSource audioSrc;

    private MonsterBrain brain;
    NavMeshAgent agent;
    private bool canSeePlayer;
    private bool canAtk = true;

    
    [Header("Player Componenets")]
    [SerializeField] Transform player;
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private Animator anim;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        brain = gameObject.GetComponent<MonsterBrain>();
        agent.speed = monsterSpeed;
        MonsterStates();
    }

    void Update()
    {
        CanSeePlayer();
    }
    
    //sets the different states the monster can have
    void MonsterStates()
    {
        brain.AddState(new IdleState("inIdle",this,1f));
        brain.AddState(new PatrolState("inWalking",this,2f,route,3f));
        brain.AddState(new ChaseState("inChase", this,3f ,monsterSpeed));
        brain.AddState(new AttackState("inAttack", this, 4f, attackRange));
    }

    //shoots a raycast to the player to act like line of sight for the player
    void CanSeePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        Ray playerLOS = new Ray(transform.position, directionToPlayer);
        Debug.DrawRay(transform.position,playerLOS.direction * sightRange,Color.blue);

        if (Physics.Raycast(playerLOS, out RaycastHit hit, sightRange))
        {
            
            if (hit.collider.CompareTag("Player") == true && hit.collider.CompareTag("Hidden") != true)
            {
                audioSrc.Play();
                canSeePlayer = true;
            }
            else
            {
                canSeePlayer = false;
            }
        }
        else
        {
            canSeePlayer = false;
        }
    }
   
    //Getter methods
    public Transform GetPlayer()
    {
        return player;
    }
    
    public float GetDistanceFromPlayer()
    {
        return Vector3.Distance(transform.position, player.position);
    }

    public void SetMonsterSpeed(float newSpeed)
    {
        monsterSpeed = newSpeed;
        agent.speed = monsterSpeed;
    }
    
    public bool GetCanSeePlayer()
    {
        return canSeePlayer;
    }
    
    public void SetAnimation(string animName, bool inAnim)
    {
        anim.SetBool(animName, inAnim);
    }

    public Animator GetAnimator()
    {
        return anim;
    }
    
    //Sets the navmesh to go to a specific point
    public void SetMonsterDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void CancelMonsterDestination()
    {
        agent.ResetPath();
    }

    public void SpawnAttackBox()
    {
        if (canAtk == true)
        {
            var attackBox = Instantiate(this.attackBox, attackBoxSpawn.position, Quaternion.identity);
            canAtk = false;
            Invoke(nameof(ResetAtk), 2f);
        }
    }

    public void SetCanAtk(bool newCanAtk)
    {
        canAtk = newCanAtk;
    }
    public bool GetCanAtk()
    {
        return canAtk;
    }
    
    public Transform GetAtkBoxSpawn()
    {
        return attackBoxSpawn;
    }
    
    void ResetAtk()
    {
        canAtk = true;
    }

}
