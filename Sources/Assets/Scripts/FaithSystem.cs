using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaithSystem : MonoBehaviour
{
    private int faith;

    public void AddFaith(int faith)
    {
        this.faith += this.faith;
    }

    public void RemoveFaith(int faith)
    {
        this.faith -= faith;
    }
    
    public int Faith => faith;
    
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
