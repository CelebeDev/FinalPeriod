using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseMonster : MonoBehaviour
{
    [SerializeField] Transform playerObj;
    [SerializeField] private NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerObj.position);
    }

    public void SetPlayerTransform(Transform player)
    {
        playerObj = player;
    }
}
