using System;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Text countdownTimer;
    public int startingTime;
    public bool isEnabled = true; // TODO: set to false in production
    
    private Animator animator;
    private GameObject instructions;

    private float timeRemaining;
    public bool isGameFinished = false;
    
    public bool isShown = false;
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        
        animator = GetComponent<Animator>();
        instructions = GameObject.FindGameObjectWithTag("Instructions");
        instructions.SetActive(false);
    }

    private void Start()
    {
        timeRemaining = startingTime;
    }

    private void Update()
    {
        if(!isEnabled)
            return;

        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMap();
        }

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            countdownTimer.text = "Countdown:\n" + ((int) timeRemaining) + " seconds";
        }
        else
        {
            if (!isGameFinished)
            {
                SceneChanger.Instance.LoadScene("Endscreen");
                isGameFinished = true;
            }
        }
    }

    public void ToggleMap()
    {
        isShown = !isShown;
        animator.SetBool(IsOpen, isShown);
    }
    
    public void HideMap()
    {
        isShown = false;
        animator.SetBool(IsOpen, isShown);
    }
    
    public void EnableMap()
    {
        isEnabled = true;
        instructions.SetActive(true);
    }
    
    public void DisableMap()
    {
        isEnabled = false;
        instructions.SetActive(false);
    }

    public void FastForwardCountdown()
    {
        timeRemaining = 1f;
    }

    public void Reset()
    {
        MapManager.Instance.HideMap();
        MapManager.Instance.isEnabled = false;
        MapManager.Instance.isGameFinished = false;
        MapManager._instance.timeRemaining = 60 * 7;
    }

    private static MapManager _instance;
    public static MapManager Instance { get { return _instance; } }
}
