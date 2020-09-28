using UnityEngine;

public class Ghetto : MonoBehaviour
{
    public Dialogue[] dialogues;

    public GameObject racoon;
    
    void Start()
    {
        if(ProgressTracker.RacoonAvailable)
            racoon.SetActive(true);
        
        if (ProgressTracker.RacoonMinigameDone)
        {
            racoon.GetComponent<DialogueTrigger>().dialogue = dialogues[1];
        }
        else
        {
            racoon.GetComponent<DialogueTrigger>().dialogue = dialogues[0];
        }
    }
}
