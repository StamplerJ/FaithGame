using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public DialogueTrigger trigger;
    
    void Start()
    {
        trigger.TriggerDialogue();
    }
}
