using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInstructions : MonoBehaviour
{
    void Start()
    {
        PrintInstructions();
    }

    public void PrintInstructions()
    {
        Debug.Log("Welcome to the game!");
        Debug.Log("Push WASD to move");
        Debug.Log("Don't touch walls");
    }
}
