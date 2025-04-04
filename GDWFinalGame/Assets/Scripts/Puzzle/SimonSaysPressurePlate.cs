using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysPressurePlate : MonoBehaviour
{
    public int plateIndex; // Assign a unique index for each plate
    public SimonSaysPuzzle simonSaysPuzzle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            simonSaysPuzzle.PlayerSteppedOnPlate(plateIndex);
        }
    }
}
