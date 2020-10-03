using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class FaithSystem : MonoBehaviour
{
    public Text faithText;
    public GameObject toast;

    public int faithNeeded;
    public int faithCatched;

    private int faith;

    private Text toastText;
    private Animator animator;

    private void Start()
    {
        UpdateFaithText();
    }

    public void AddFaith(int faith)
    {
        this.faith += faith;
        ShowFaithToast(faith, 2);
        UpdateFaithText();
    }

    public void RemoveFaith(int faith)
    {
        this.faith -= faith;
        ShowFaithToast(faith, 2);
        UpdateFaithText();
    }

    public void UpdateFaithText()
    {
        faithText.text = "Faith:\n" + faith + " / " + faithNeeded;
    }
    
    public int Faith
    {
        get => faith;
        set => faith = value;
    }
    
    public void ShowFaithToast(int faith, int duration)
    {
        StartCoroutine(ShowToastCOR(faith + (faith > 0 ? " Faith gained!" : " Faith lost!"), duration));
    }

    private IEnumerator ShowToastCOR(string text, int duration)
    {
        Color orginalColor = toastText.color;

        toastText.text = text;

        //Fade in
        yield return FadeInAndOut(toastText, true, 0.5f);

        //Wait for the duration
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            yield return null;
        }

        //Fade out
        yield return FadeInAndOut(toastText, false, 0.5f);

        toastText.color = orginalColor;
    }

    IEnumerator FadeInAndOut(Text targetText, bool fadeIn, float duration)
    {
        //Set Values depending on if fadeIn or fadeOut
        float a, b;
        if (fadeIn)
        {
            a = 0f;
            b = 1f;
        }
        else
        {
            a = 1f;
            b = 0f;
        }
        
        animator.SetBool(IsShown, fadeIn);

        Color currentColor = Color.white;
        float counter = 0f;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            float alpha = Mathf.Lerp(a, b, counter / duration);

            targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
            yield return null;
        }
    }
    
    private static FaithSystem _instance;
    private static readonly int IsShown = Animator.StringToHash("IsShown");

    public static FaithSystem Instance { get { return _instance; } }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        toastText = toast.GetComponentInChildren<Text>();
        animator = GetComponent<Animator>();
    }
}
