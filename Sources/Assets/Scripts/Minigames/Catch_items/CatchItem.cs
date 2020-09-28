using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItem : MonoBehaviour
{
    public float fallSpeed = 6f;

    public int faith;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector3.down * (fallSpeed * Time.deltaTime));

        if (transform.position.y < -6f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
