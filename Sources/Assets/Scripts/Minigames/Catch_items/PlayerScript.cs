﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public ItemSpawner itemSpawner;
    public GameObject startScreen, finishedScreen;
    public Text faithText, collectedText;
    public GameObject leftWall, rightWall;
    
    public float speed = 20f;
    public int maxCollected = 20;

    private int faithCounter;
    private float collectedCounter;

    private bool isActive = false;

    void Start()
    {
        faithCounter = 0;
        UpdateFaith(faithCounter);
    }

    void Update()
    {
        if (!isActive) 
            return;
        
        float direction = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0f, 0f));

        var position = transform.position;
        if (transform.position.x > rightWall.transform.position.x - rightWall.transform.localScale.x / 2f)
        {
            position = new Vector3(rightWall.transform.position.x - rightWall.transform.localScale.x / 2f,
                position.y, position.z);
            transform.position = position;
        }
        else if (transform.position.x < leftWall.transform.position.x + leftWall.transform.localScale.x / 2f)
        {
            position = new Vector3(leftWall.transform.position.x + leftWall.transform.localScale.x / 2f, position.y,
                position.z);
            transform.position = position;
        }
    }

    private void OnMouseDrag()
    {
        if (!isActive) 
            return;
        
        var position = transform.position;
        
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
        transform.position = new Vector3(curPosition.x, position.y, position.z);
        
        if (transform.position.x > rightWall.transform.position.x - rightWall.transform.localScale.x / 2f)
        {
            position = new Vector3(rightWall.transform.position.x - rightWall.transform.localScale.x / 2f,
                position.y, position.z);
            transform.position = position;
        }
        else if (transform.position.x < leftWall.transform.position.x + leftWall.transform.localScale.x / 2f)
        {
            position = new Vector3(leftWall.transform.position.x + leftWall.transform.localScale.x / 2f, position.y,
                position.z);
            transform.position = position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActive) 
            return;
        
        if (other.tag.Equals("CatchItem"))
        {
            CatchItem item = other.GetComponent<CatchItem>();
            UpdateFaith(item.faith);
            UpdateCollected();
            Destroy(other.gameObject);
        }
    }

    private void UpdateFaith(int faith)
    {
        faithCounter += faith;
        faithText.text = "Faith: " + faithCounter;
    }
    
    private void UpdateCollected()
    {
        collectedText.text = "Collected: " + ++collectedCounter;

        if (collectedCounter >= maxCollected)
        {
            OnFinish();
        }
    }

    private void OnFinish()
    {
        isActive = false;
        itemSpawner.gameObject.SetActive(false);
            
        // FaithSystem.Instance.AddFaith(faithCounter);
        
        // faithResult.text = faithCounter + " Faith";

        FaithSystem.Instance.faithCatched = faithCounter;

        ProgressTracker.RacoonMinigameDone = true;
        
        finishedScreen.SetActive(true);
    }

    public void OnStartGame()
    {
        isActive = true;
        startScreen.SetActive(false);
        itemSpawner.gameObject.SetActive(true);
        
        MapManager.Instance.DisableMap();
    }

    public void OnGoBack()
    {
        SceneChanger.Instance.LoadLastScene();
        
        MapManager.Instance.EnableMap();
    }
}
