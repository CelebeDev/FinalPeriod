using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAtkBox : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerClass").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Player dead");
            player.SetPlayerDead(true);
        }
    }
}
