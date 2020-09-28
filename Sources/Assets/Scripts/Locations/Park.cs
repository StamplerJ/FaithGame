using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Park : MonoBehaviour
{
    public Dialogue[] dialogues;

    public GameObject penner;
    
    void Start()
    {
        if (ProgressTracker.RacoonMinigameDone)
        {
            penner.GetComponent<DialogueTrigger>().dialogue = dialogues[1];
            if (!ProgressTracker.HomelessDelivered)
            {
                FaithSystem.Instance.AddFaith(FaithSystem.Instance.faithCatched);
                ProgressTracker.HomelessDelivered = true;
            }
        }
        else
        {
            penner.GetComponent<DialogueTrigger>().dialogue = dialogues[0];
        }
    }
}
