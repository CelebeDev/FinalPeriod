using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtkBox : MonoBehaviour
{
    private Monster monster;
    private Player player;

    void Start()
    {
        monster = GameObject.FindGameObjectWithTag("Monster").GetComponent<Monster>();
        player = GameObject.FindGameObjectWithTag("PlayerClass").GetComponent<Player>();
    }

    void Update()
    {
        Destroy(gameObject, 2f);
        gameObject.transform.position = monster.GetAtkBoxSpawn().position;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("attacking the player");
            player.SetPlayerDead(true);
        }
    }
}
