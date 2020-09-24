using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    
    private string currentScene;
    private Stack<string> lastScenes;
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        
        currentScene = SceneManager.GetActiveScene().name;
        lastScenes = new Stack<string>();
    }

    public void LoadScene(string sceneName)
    {
        lastScenes.Push(currentScene);
        currentScene = sceneName;

       StartCoroutine(Load());
    }

    public void LoadLastScene()
    {
        if (lastScenes.Count <= 0)
            return;
        
        currentScene = lastScenes.Pop();
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        transition.SetTrigger("StartFading");

        yield return new WaitForSeconds(transitionTime);
        
        SceneManager.LoadScene(currentScene);
    }
    
    private static SceneChanger _instance;

    public static SceneChanger Instance { get { return _instance; } }
}
