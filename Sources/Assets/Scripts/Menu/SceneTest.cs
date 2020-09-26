using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTest : MonoBehaviour
{
    public void OnCatchItems()
    {
        SceneChanger.Instance.LoadScene("Minigame_Catch_Items");
    }
}
