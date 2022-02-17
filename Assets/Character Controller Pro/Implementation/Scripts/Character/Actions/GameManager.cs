using System.Collections;
using System.Collections.Generic;
using Lightbug.CharacterControllerPro.Implementation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Character State Identifier")] public bool inLedge;
    private bool alreadyLedgeControlSet = false;

    public enum InState
    {
        inNormal,
        inLedge,
        inClimb,
    }

    public InState inState = InState.inNormal;
        
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        // controlCharacterAction.setMovementY();
            
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}

