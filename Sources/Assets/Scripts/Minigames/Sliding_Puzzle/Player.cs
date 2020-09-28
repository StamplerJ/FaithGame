using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject startScreen, finishedScreen;
    public Text finishText;

    private bool isActive = false;
    private bool isFinished = false;
    
    private void Update()
    {
        if (transform.position.y <= -5f )
        {
            if (!isFinished)
            {
                OnFinish();
                isFinished = true;
            }
        }
    }

    private void OnFinish()
    {
        isActive = false;
            
        // FaithSystem.Instance.AddFaith(faithCounter);
        
        // faithResult.text = faithCounter + " Faith";

        ProgressTracker.PetStoreMinigameDone = true;
        
        finishedScreen.SetActive(true);

        if (ProgressTracker.SuburbBlockRemoved)
        {
            finishText.text = "Oh no, because of the missing barrier the animals were killed on the street....\n" +
                         "You loose 1000 Faith";
            
            FaithSystem.Instance.RemoveFaith(1000);
        }
        else
        {
            finishText.text = "You freed the animals!\n" +
                              "You earn 1000 Faith";
            
            FaithSystem.Instance.AddFaith(1000);
        }
    }

    public void OnStartGame()
    {
        isActive = true;
        startScreen.SetActive(false);
        
        MapManager.Instance.DisableMap();
    }

    public void OnGoBack()
    {
        SceneChanger.Instance.LoadLastScene();
        
        MapManager.Instance.EnableMap();
    }
}
