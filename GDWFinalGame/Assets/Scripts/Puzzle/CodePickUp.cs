using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePickUp : MonoBehaviour
{
    [SerializeField] PuzzleCode puzzleCode;
    [SerializeField] AudioSource audioSrc;

    void Update()
    {
        transform.Rotate(0f, 45f * Time.deltaTime, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.gameObject.GetComponentInParent<Player>().IncrementCollectableCount();
            audioSrc.Play();
            puzzleCode.RemoveCodeFromList(gameObject);
            Invoke(nameof(SetCodeToNotActive), 1f);
        }
    }

    void SetCodeToNotActive()
    {
        gameObject.SetActive(false);
    }
}
