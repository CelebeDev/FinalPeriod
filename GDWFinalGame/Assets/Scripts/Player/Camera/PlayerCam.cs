using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("Camera Vars")]
    [SerializeField] float sens;
    
    [Header("Camera Componenets")] 
    [SerializeField] private Transform playerObj;
    [SerializeField] private Transform playerModel;
    [SerializeField] private Transform orientation;
    private float xRotation;
    private float yRotation;
    [SerializeField] private Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetPlayerDead() == false)
        {
            PlayerMouseInput();
        }
    }

    void PlayerMouseInput()
    {
        var mouseRotationX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens;
        var mouseRotationY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;

        yRotation += mouseRotationX;
        xRotation -= mouseRotationY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        playerObj.rotation = Quaternion.Euler(0, yRotation, 0);

       
        playerModel.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
