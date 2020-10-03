using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Dialogue conversationEndedDialogue;

    [HideInInspector]
    public Response response;

    public Material outlineMaterial;

    private Material standardMaterial;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        
        if(spriteRenderer != null)
            standardMaterial = spriteRenderer.sharedMaterial;
    }

    private void OnMouseDown()
    {
        if(MapManager.Instance.isShown)
            return;
        
        TriggerDialogue();
    }

    private void OnMouseEnter()
    {
        if(MapManager.Instance.isShown)
            return;
        
        spriteRenderer.sharedMaterial = outlineMaterial;
    }

    private void OnMouseExit()
    {
        if(MapManager.Instance.isShown)
            return;
        
        spriteRenderer.sharedMaterial = standardMaterial;
    }

    public void TriggerDialogue()
    {
        if(dialogue != null)
            DialogueManager.Instance.StartDialog(dialogue);
    }

    public void TriggerResponse()
    {
        DialogueManager.Instance.DisplayNextMessage(response.next);

        // Very bad hack, never do this in real life
        if(SceneManager.GetSceneAt(1) != null && SceneManager.GetSceneAt(1).name.Equals("Vorstadt"))
            FaithSystem.Instance.AddFaith((ProgressTracker.SuburbBlockRemoved ? 50 : -50));
        
        // Very bad, too!
        if (SceneManager.GetSceneAt(1) != null && SceneManager.GetSceneAt(1).name.Equals("Park"))
        {
            if (ProgressTracker.RacoonMinigameDone)
            {
                if (!ProgressTracker.HomelessDelivered)
                {
                    FaithSystem.Instance.AddFaith(FaithSystem.Instance.faithCatched);
                    ProgressTracker.HomelessDelivered = true;
                }
            }
        }

        if (response.triggerMap != null)
        {
            SceneChanger.Instance.LoadScene(response.triggerMap.name);
        }
    }
}

