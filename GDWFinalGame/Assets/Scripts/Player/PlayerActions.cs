using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Basic Movement")]
    private Player player;
    
    private float horizontalInput;
    private float verticalInput;
    private float resetMaxSpeed;
    
    
    private Vector3 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        resetMaxSpeed = player.GetPlayerMaxSpeed();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.GetPlayerDead() == false)
        {
            PlayerSprint();
            MovePlayer();

        }
    }
    
    void MovePlayer()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        moveDir = transform.forward * verticalInput + transform.right * horizontalInput;
        
        if (Mathf.Abs(player.GetRigidbody().velocity.magnitude) >= player.GetPlayerMaxSpeed())
        {
            return;
        }



 
        player.GetRigidbody().AddForce(moveDir * player.GetPlayerSpeed(), ForceMode.Force);
    }

    void PlayerSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && player.GetStamina() > 0)
        {
            player.SetStamina(player.GetStamina() - 1);
            player.SetPlayerMaxSpeed(10);
        }
        else
        {
            player.SetPlayerMaxSpeed(resetMaxSpeed);
        }
    }


}
