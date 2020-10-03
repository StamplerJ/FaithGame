using System;
using UnityEngine;

public class Vorstadt : MonoBehaviour
{
    public bool isBlockerFlat;
    
    public Dialogue dialogueBlockerStanding, dialogBlockerFlat;

    public GameObject blocker;
    public Sprite blockerStanding, blockerFlat;

    void Start()
    {
        isBlockerFlat = ProgressTracker.SuburbBlockRemoved;
        
        blocker.GetComponentInChildren<SpriteRenderer>().sprite =
            (ProgressTracker.SuburbBlockRemoved ? blockerFlat : blockerStanding);

        blocker.GetComponent<DialogueTrigger>().dialogue =
            (ProgressTracker.SuburbBlockRemoved ? dialogBlockerFlat : dialogueBlockerStanding);
    }

    private void OnMouseDown()
    {
        ToggleBlocker();
    }

    public void ToggleBlocker()
    {
        isBlockerFlat = !isBlockerFlat;

        ProgressTracker.SuburbBlockRemoved = isBlockerFlat;
    }
}
