using UnityEngine;

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

        if (response.triggerMap != null)
        {
            SceneChanger.Instance.LoadScene(response.triggerMap.name);
        }
    }
}

