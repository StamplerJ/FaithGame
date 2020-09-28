using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Vorstadt : MonoBehaviour
{
    public bool isBlockerFlat;
    
    public Dialogue[] dialogues;

    public GameObject blocker;
    public Sprite blockerStanding, blockerFlat;

    void Start()
    {
        ProgressTracker.SuburbBlockRemoved = isBlockerFlat;
        
        blocker.GetComponentInChildren<SpriteRenderer>().sprite =
            (ProgressTracker.SuburbBlockRemoved ? blockerFlat : blockerStanding);
    }
}
