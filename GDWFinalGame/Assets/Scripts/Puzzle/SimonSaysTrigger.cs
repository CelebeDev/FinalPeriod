using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysTrigger : MonoBehaviour
{
    public SimonSaysPuzzle gameController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameController.StartGame();
        }
    } 
}
