using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LocationInteractable : MonoBehaviour
{
    public MapPart destination;
    public Material outlineMaterial;
    
    private SpriteRenderer spriteRenderer;
    private Material standardMaterial;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        standardMaterial = spriteRenderer.sharedMaterial;
    }

    public void OnMouseDown()
    {
        if(destination != null)
            SceneChanger.Instance.LoadScene(destination.name);
        
        MapManager.Instance.HideMap();
    }
    
    private void OnMouseEnter()
    {
        spriteRenderer.sharedMaterial = outlineMaterial;
    }

    private void OnMouseExit()
    {
        spriteRenderer.sharedMaterial = standardMaterial;
    }
}
