using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private const string ParentScene = "ParentScene";
    
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
        
        // Get current scene except ParentScene
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (!SceneManager.GetSceneAt(i).name.Equals(ParentScene))
            {
                currentScene = SceneManager.GetSceneAt(i).name;
            }
        }
        lastScenes = new Stack<string>();
    }

    public void LoadScene(string sceneName)
    {
        if (currentScene.Length == 0)
            return;

        lastScenes.Push(currentScene);
        StartCoroutine(Load(sceneName));
    }

    IEnumerator Load(string newScene)
    {
        transition.SetTrigger("FadeIn");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene(newScene, LoadSceneMode.Additive);
        currentScene = newScene;

        transition.SetTrigger("FadeOut");
    }

    public void LoadLastScene()
    {
        if (lastScenes.Count <= 0)
            return;
        
        StartCoroutine(Load(lastScenes.Pop()));
    }

    private static SceneChanger _instance;

    public static SceneChanger Instance { get { return _instance; } }
}
