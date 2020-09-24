using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaithSystem : Singleton<FaithSystem>
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
}
