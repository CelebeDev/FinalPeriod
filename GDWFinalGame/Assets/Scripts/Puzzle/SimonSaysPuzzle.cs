using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSaysPuzzle : MonoBehaviour
{
    [SerializeField] GameObject displayObject; 
    [SerializeField] Material[] colorMaterials; 
    [SerializeField] SimonSaysPressurePlate[] pressurePlates; 
    [SerializeField] GameObject doorObject; 
    [SerializeField] int roundsToWin = 3;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private AudioClip audioClipCorrect;
    [SerializeField] AudioClip audioClipWrong;

    private List<int> sequence = new List<int>();
    private int currentStep = 0;
    private int completedRounds = 0;
    private bool playerInputActive = false;
    private bool gameStarted = false;

    void Start()
    {
        ResetGame();
    }

    public void StartGame()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            StartNewRound();
        }
    }

    void StartNewRound()
    {
        sequence.Add(Random.Range(0, colorMaterials.Length)); 
        StartCoroutine(DisplaySequence());
    }

    IEnumerator DisplaySequence()
    {
        playerInputActive = false; 
        currentStep = 0;

        foreach (int index in sequence)
        {
            displayObject.GetComponent<Renderer>().material = colorMaterials[index];
            yield return new WaitForSeconds(1f);
            displayObject.GetComponent<Renderer>().material = null;
            yield return new WaitForSeconds(0.5f);
        }

        playerInputActive = true;
    }

    public void PlayerSteppedOnPlate(int plateIndex)
    {
        if (!playerInputActive) return;

        if (plateIndex == sequence[currentStep])
        {
            currentStep++;
            if (currentStep >= sequence.Count)
            {
                completedRounds++;
                Debug.Log("Correct sequence! Round " + completedRounds + " completed.");
                
                audioSource.clip = audioClipCorrect;
                audioSource.Play();

                if (completedRounds >= roundsToWin)
                {
                    Destroy(doorObject);
                    Debug.Log("You won! Door is now open.");
                }
                else
                {
                    StartCoroutine(NextRoundDelay());
                }
            }
        }
        else
        {
            Debug.Log("Wrong input! Restarting...");
            audioSource.clip = audioClipWrong;
            audioSource.Play();
            ResetGame();
        }
    }

    void ResetGame()
    {
        sequence.Clear();
        completedRounds = 0;
        gameStarted = false;
    }

    IEnumerator NextRoundDelay()
    {
        yield return new WaitForSeconds(1f);
        StartNewRound();
    }
}
