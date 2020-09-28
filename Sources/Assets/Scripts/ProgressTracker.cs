using System;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public static bool Start = false;
    public static bool RacoonAvailable = false;
    public static bool RacoonMinigameDone = false;
    public static bool HomelessIntro = false;
    public static bool HomelessDelivered = false;
    public static bool PetStoreWoman = false;
    public static bool PetStoreMinigameDone = false;
    public static bool SuburbBlockRemoved = false;
    
    public void ResetProgress()
    {
        Start = false;
        RacoonAvailable = false;
        RacoonMinigameDone = false;
        HomelessIntro = false;
        HomelessDelivered = false;
        PetStoreWoman = false;
        PetStoreMinigameDone = false;
        SuburbBlockRemoved = false;
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
 
    private static ProgressTracker _instance;
    public static ProgressTracker Instance { get { return _instance; } }
}
