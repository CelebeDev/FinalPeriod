using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCode : MonoBehaviour
{
    [SerializeField] List<GameObject> puzzleCodes = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HasCodes();
    }


    void HasCodes()
    {
        if (puzzleCodes.Count == 0)
        {
            
        }
    }


    public void RemoveCodeFromList(GameObject code)
    {
        puzzleCodes.Remove(code);
    }

    public int GetAmountOfCodes()
    {
        return puzzleCodes.Count;
    }
}
