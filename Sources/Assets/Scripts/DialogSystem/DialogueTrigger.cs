using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Response response;

    public void TriggerDialogue()
    {
        if(dialogue != null)
            DialogueManager.Instance.StartDialog(dialogue);
    }

    public void TriggerResponse()
    {
        DialogueManager.Instance.DisplayNextMessage(response.next);
        
        if (response.triggerMap != null)
        {
            SceneChanger.Instance.LoadScene(response.triggerMap.name);
        }
    }
}

