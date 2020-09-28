using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    public Text endText;
    public Image endImage;

    public Sprite winSprite;
    public Sprite looseSprite;
    
    void Start()
    {
        if (FaithSystem.Instance.Faith >= FaithSystem.Instance.faithNeeded)
        {
            endText.text = "Nice! You achieved " + FaithSystem.Instance.Faith + " Faith.\nYou are saved from this world!";
            endImage.sprite = winSprite;
        }
        else
        {
            endText.text = "Sorry, your only achieved " + FaithSystem.Instance.Faith + " Faith.\nYou won't be going to heaven...";
            endImage.sprite = looseSprite;
        }
    }
}
