using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float stamina;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioSource audioSrc;
    [SerializeField] AudioClip audioClip;
    [SerializeField] private Dictionary<string, GameObject> keyInventory = new Dictionary<string, GameObject>();//HOLDS THE NAME OF THE KEY THAT THE PLAYER HAS
    private int collectableIncrement;
    private float resetStamina;
    private bool isDead = false;
    private bool playDeathSoundEffect = true;
    private bool canResetStamina = false;
    
    // Start is called before the first frame update
    void Start()
    {
        resetStamina = stamina;
    }

    // Update is called once per frame
    void Update()
    {
        RegenStamina();

        if (isDead == true)
        {
            if (playDeathSoundEffect)
            {
                audioSrc.clip = audioClip;
                audioSrc.Play();
                playDeathSoundEffect = false;
            }
        }
        
        if(canResetStamina)
            Invoke(nameof(ResetStamina), 6f);
        
    }
    
    void RegenStamina()
    {
        if (stamina == 0)
        {
            canResetStamina = true;
        }
        else if(rb.velocity.magnitude == 0){
            if (stamina < resetStamina)
            {
                stamina += 1;
            }
        }
    }

    public void IncrementCollectableCount()
    {
        collectableIncrement++;
    }

    public int GetCollectableCount()
    {
        return collectableIncrement;
    }

    public bool GetPlayerDead()
    {
        return isDead;
    }
    
    public void SetPlayerDead(bool isPlayerDead)
    {
        isDead = isPlayerDead;
    }
    
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
    public float GetPlayerSpeed()
    {
        return moveSpeed;
    }

    public float GetPlayerMaxSpeed()
    {
        return maxSpeed;
    }
    
    public void SetPlayerMaxSpeed(float newMaxSpeed)
    {
        maxSpeed = newMaxSpeed;
    }

    public float GetStamina()
    {
        return stamina;
    }
    
    public void SetStamina(float newStamina)
    {
        stamina = newStamina;
    }

    public Dictionary<string, GameObject> GetKeyList()
    {
        return keyInventory;
    }
    
    void ResetStamina()
    {
        stamina = resetStamina;
        canResetStamina = false;
    }
}
