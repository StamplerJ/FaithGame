using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PennerTriggered : MonoBehaviour
{
    private void OnMouseDown()
    {
        ProgressTracker.RacoonAvailable = true;
    }
}
