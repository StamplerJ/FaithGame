using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turntable : MonoBehaviour
{
    public GameObject character;
    private Vector3 currentRotation;
    private Vector3 targetRotation;
    float t = 0f;
    float elapsed = 0f;
    public float duration;
    bool lerpForward = false;
    bool lerpBackwards;
    public int state;
    public GameObject image;
    public Button selectButton;
    private Text selectText;

    private void Awake()
    {
        selectText = selectButton.GetComponentInChildren<Text>();
    }

    void Update()
    {
        RotateTurntable();
        VisibilityTextbox(image);
    }

    private void RotateTurntable()
    {
        if (currentRotation != targetRotation && lerpForward == true)
        {
            character.transform.eulerAngles = Vector3.Lerp(currentRotation, targetRotation, t);
            t = elapsed / duration;
            if (elapsed < duration)
            {
                elapsed += Time.deltaTime;
            }
            else if (elapsed >= duration)
            {
                elapsed = duration;
                lerpForward = false;
            }
        }

        if (currentRotation != targetRotation && lerpBackwards == true)
        {
            character.transform.eulerAngles = Vector3.Lerp(currentRotation, targetRotation, t);
            t = elapsed / duration;
            if (elapsed < duration)
            {
                elapsed += Time.deltaTime;
            }
            else if (elapsed >= duration)
            {
                elapsed = duration;
                lerpBackwards = false;
            }
        }
    }

    public void RotateCharacterForward()
    {
        if (lerpForward == false && lerpBackwards == false)
        {
            currentRotation = character.transform.eulerAngles;
            targetRotation = character.transform.eulerAngles + new Vector3(0f, 120f, 0f);
            t = 0f;
            elapsed = 0f;
            lerpForward = true;
            if (state < 2)
            {
                state++;
            }

            else if (state >= 2)
            {
                state = 0;
            }
        }
    }

    public void RotateCharacterBackwards()
    {
        if (lerpBackwards == false && lerpForward == false)
        {
            currentRotation = character.transform.eulerAngles;
            targetRotation = character.transform.eulerAngles + new Vector3(0f, -120f, 0f);
            t = 0f;
            elapsed = 0f;
            lerpBackwards = true;

            if (state > 0)
            {
                state--;
            }
            else if (state <= 0)
            {
                state = 2;
            }
        }
    }

    private void VisibilityTextbox(GameObject image)
    {
        if (state == 0)
        {
            image.SetActive(true);

            if (name.Equals("Miles"))
            {
                selectButton.interactable = true;
                selectText.enabled = false;
            }
            else
            {
                selectButton.interactable = false;
                selectText.enabled = true;
            }
        }
        else
        {
            image.SetActive(false);
        }
    }
}
