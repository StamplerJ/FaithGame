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
        image.material = outlineMaterial;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.material = standardMaterial;
    }

    public void OnSelectCharacter()
    {
        MapManager.Instance.EnableMap();

        if(destination != null)
            SceneChanger.Instance.LoadScene(destination.name);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    private void OnValidate()
    {
        GetComponentInChildren<Text>().text = this.name;
    }
}
