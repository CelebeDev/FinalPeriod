using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlatePuzzle : MonoBehaviour
{

    [SerializeField] private List<int> correctCode;
    [SerializeField] private List<int> pressedPressurePlates;

    [SerializeField] private GameObject puzzleDoor;
    [SerializeField] AudioSource audioSrc;
    [SerializeField] AudioClip audioCorrect;
    [SerializeField] AudioClip audioIncorrect;
    


    public void CheckCode(int id)
    {
        pressedPressurePlates.Add(id);

        for (int i = 0; i < correctCode.Count; i++)
        {
            if (pressedPressurePlates[i] != correctCode[i])
            {
                pressedPressurePlates.Clear();
                audioSrc.clip = audioIncorrect;
                audioSrc.Play();
                return;
            }
            
            audioSrc.clip = audioCorrect;
            audioSrc.Play();
        }

        if (pressedPressurePlates.Count == correctCode.Count)
        {
            Destroy(puzzleDoor);
        }
    }
    
}
