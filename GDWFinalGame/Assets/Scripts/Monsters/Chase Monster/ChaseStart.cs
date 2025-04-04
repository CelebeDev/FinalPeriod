using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStart : MonoBehaviour
{
    [SerializeField] private Transform monsterSpawn;
    [SerializeField] private GameObject Monster;
    [SerializeField] private GameObject Block;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Monster Spawned for chase scene");
            GameObject monster = Instantiate(Monster, monsterSpawn.position, Quaternion.identity);
            monster.GetComponent<ChaseMonster>().SetPlayerTransform(other.gameObject.GetComponent<Transform>());
            Block.SetActive(true);
            Destroy(gameObject);//destroys the chase scene trigger
        }
    }
}
