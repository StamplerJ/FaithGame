using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tierheim : MonoBehaviour
{
    public GameObject petShopWoman;
    public Dialogue[] dialogues;

    void Start()
    {
        if (ProgressTracker.PetStoreMinigameDone)
        {
            petShopWoman.GetComponent<DialogueTrigger>().dialogue = dialogues[1];
        }
        else
        {
            petShopWoman.GetComponent<DialogueTrigger>().dialogue = dialogues[0];
        }
    }
}
