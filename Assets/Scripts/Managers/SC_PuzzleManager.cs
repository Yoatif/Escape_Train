using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PuzzleManager
{
    [SerializeField]
    private bool[] puzzlesStates = new bool[6];
    public int puzzleNumber;
    public bool newState;


    public virtual void CreatePuzzles()
    {
        for(int puzzleNumber = 0; puzzleNumber < puzzlesStates.Length; puzzleNumber++)
        {
            puzzlesStates[puzzleNumber] = false;
            
        }
    }
    public virtual void UpdatePuzzles()
    {
        if (puzzleNumber >= 0 && puzzleNumber < puzzlesStates.Length)
        {
            puzzlesStates[puzzleNumber] = newState;
            Debug.Log("L'état du puzzle " + puzzleNumber + " a été modifié à : " + newState);
        }
    }
}
