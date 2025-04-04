using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHiding : MonoBehaviour
{
    private int i = 1;
    private GameObject player;
    [SerializeField] private Transform camPos;
    [SerializeField] private Transform hidingPlace;
    [SerializeField] private Transform exitHidingPlace;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InHiding();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.tag = "Hidden";
            i++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hidden"))
        {
            Debug.Log("exiting");
            other.gameObject.tag = "Player";
            player = other.gameObject;
        }
    }

    public void InHiding()
    {
        if (i % 2 == 0)
        {
        }
        else
        {
        }
    }
}
