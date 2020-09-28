using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class FaithSystem : MonoBehaviour
{
    public Text faithText;

    public int faithNeeded;
    
    private int faith;

    public int faithCatched;

    private void Start()
    {
        UpdateFaithText();
    }

    public void AddFaith(int faith)
    {
        this.faith += faith;
        UpdateFaithText();
    }

    public void RemoveFaith(int faith)
    {
        this.faith -= faith;
        UpdateFaithText();
    }

    public void UpdateFaithText()
    {
        faithText.text = faith + " / " + faithNeeded;
    }
    
    public int Faith
    {
        get => faith;
        set => faith = value;
    }

    private static FaithSystem _instance;

    public static FaithSystem Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }
}
