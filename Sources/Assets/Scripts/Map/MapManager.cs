using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Text faith;
    public Text time;

    public bool isEnabled = true; // TODO: set to false in production
    
    private Animator animator;
    private GameObject instructions;

    private bool isShown = false;
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        
        animator = GetComponent<Animator>();
        instructions = GameObject.FindGameObjectWithTag("Instructions");
        instructions.SetActive(false);
    }

    private void Update()
    {
        if(!isEnabled)
            return;

        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMap();
        }
    }

    public void ToggleMap()
    {
        isShown = !isShown;
        animator.SetBool(IsOpen, isShown);
    }
    
    public void HideMap()
    {
        isShown = false;
        animator.SetBool(IsOpen, isShown);
    }
    
    public void EnableMap()
    {
        isEnabled = true;
        instructions.SetActive(true);
    }
    
    private static MapManager _instance;
    public static MapManager Instance { get { return _instance; } }
}
