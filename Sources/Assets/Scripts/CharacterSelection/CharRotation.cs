using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharRotation : MonoBehaviour
{
    public GameObject plane;
    private Transform targetCamera;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetCamera = Camera.main.transform;
        targetPosition = new Vector3(0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        plane.transform.LookAt(targetCamera);
    }
}
