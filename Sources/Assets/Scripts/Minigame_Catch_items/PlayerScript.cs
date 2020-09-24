﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public GameObject finishedScreen;
    public Text faithText, collectedText, faithResult;
    public GameObject leftWall, rightWall;
    
    public float speed = 20f;
    public int maxCollected = 20;

    private float faithCounter;
    private float collectedCounter;

    private bool isActive = true;
    
    void Start()
    {
        UpdateFaith(0);
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
        GameObject.Find("ItemSpawner").SetActive(false);
            
        faithResult.text = faithCounter + " Faith";
        
        if (faithCounter < 0)
        {
            faithResult.color = Color.red;
        }
        
        finishedScreen.SetActive(true);
    }
}