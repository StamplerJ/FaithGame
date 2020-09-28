using UnityEngine;

public class CharRotation : MonoBehaviour
{
    public GameObject plane;
    private Transform targetCamera;
    
    void Start()
    {
        targetCamera = Camera.main.transform;
    }
    
    void Update()
    {
        plane.transform.LookAt(targetCamera);
    }
}