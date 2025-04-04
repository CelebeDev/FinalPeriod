using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private PressurePlatePuzzle pressurePlatePuzzle;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pressurePlatePuzzle.CheckCode(id);
        }
    }
}
