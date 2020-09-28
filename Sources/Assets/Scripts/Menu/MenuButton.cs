using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MapPart destination;
    public Material outlineMaterial;
    
    private Image image;
    private Material standardMaterial;

    private void Awake()
    {
        image = GetComponent<Image>();
        standardMaterial = image.material;
    }

    public void OnButtonClick()
    {
        if(destination != null)
            SceneChanger.Instance.LoadScene(destination.name);
        
        MapManager.Instance.HideMap();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (outlineMaterial != null)
            image.material = outlineMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.material = standardMaterial;
    }

    public void OnSelectCharacter()
    {
        MapManager.Instance.EnableMap();
        ProgressTracker.Start = true;

        OnButtonClick();
    }

    public void OnPlayAgain()
    {
        MapManager.Instance.Reset();
        FaithSystem.Instance.Faith = 0;
        
        ProgressTracker.Instance.ResetProgress();

        OnButtonClick();
    }
    
    public void OnExitClick()
    {
        Application.Quit();
    }

    private void OnValidate()
    {
        Text text = GetComponentInChildren<Text>();
        
        if(text != null)
            text.text = this.name;
    }
}
