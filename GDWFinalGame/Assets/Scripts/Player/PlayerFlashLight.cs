using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlashLight : MonoBehaviour
{
    [SerializeField] GameObject spotLight;
    [SerializeField] private AudioSource audioSrc;
    private int i = 1;
    // Start is called before the first frame update
    void Start()
    {
        spotLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FlashLightInput();
    }

    void FlashLightInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            i++;
            audioSrc.Play();
        }
        


        if (i % 2 == 0)
        {
            spotLight.SetActive(true);
        }
        else
        {
            spotLight.SetActive(false);
        }
        

    }
}
