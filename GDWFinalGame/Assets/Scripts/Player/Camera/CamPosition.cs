using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPosition : MonoBehaviour
{
    [SerializeField] Transform camPos;
   
    // Update is called once per frame
    void Update()
    {
        transform.position = camPos.position;
    }
}
