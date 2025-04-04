using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUP : MonoBehaviour
{
    [SerializeField] private string keyName;
    [SerializeField] AudioSource audioSrc;

    void Update()
    {
        transform.Rotate(0f, 45f * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        //when the player collides with pickup add the key name to the player key inventory
        if (other.gameObject.tag == "Player")
        {
            print("hitting the player");
            audioSrc.Play();
            other.gameObject.GetComponentInParent<Player>().GetKeyList().Add(keyName, gameObject);
            Destroy(gameObject, 1);

        }
    }
}
