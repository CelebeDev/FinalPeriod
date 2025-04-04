using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    [SerializeField] private string requiredKey;//the name of the key needed to open the door
    [SerializeField] private AudioSource audioSrc;
    
    void OnCollisionEnter(Collision collision)
    {
        print("A Collision Is Happening" + collision.gameObject.tag);
        //when the player collides with pickup add the key name to the player key inventory
        if (collision.gameObject.tag == "PlayerClass")
        {
            print("Player Hitting The Door");
            if (collision.gameObject.GetComponent<Player>().GetKeyList().ContainsKey(requiredKey))
            {
                print("The Player Has the Key");
                audioSrc.Play();
                Destroy(gameObject, 1f);
            }
            else
            {
                print("The Player Does Not Have the Required Key");
            }
        }
    }
}
