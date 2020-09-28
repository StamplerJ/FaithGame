using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Character playerCharacter;
    public Image playerImage;
    public Image npcImage;
    public Text characterName;
    public Text text;

    public GameObject responseButtons;
    public GameObject responseButtonPrefab;
    
    private Animator animator;
    private Dialogue currentDialogue;
    
    void Awake()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        animator = GetComponentInChildren<Animator>();
    }

    public void setupPlayer(Character character)
    {
        this.playerCharacter = character;
        playerImage.sprite = character.sprite;
    }
    
    public void StartDialog(Dialogue dialog)
    {
        animator.SetBool(IsOpen, true);

        this.currentDialogue = dialog;
        playerImage.sprite = playerCharacter.portrait;
        npcImage.sprite = dialog.character.portrait;
        
        DisplayNextMessage(0);
    }

    public void DisplayNextMessage(int index)
    {
        if (index == -1)
        {
            EndDialog();
            return;
        }

        for (int i = 0; i < responseButtons.transform.childCount; i++)
        {
            Destroy(responseButtons.transform.GetChild(i).gameObject);
        }
        
        Message message = currentDialogue.messages[index];
        
        // Show portrait image for player or npc
        playerImage.enabled = message.isPlayer;
        npcImage.enabled = !message.isPlayer;
        
        

        characterName.text = message.isPlayer ? playerCharacter.name : currentDialogue.character.name;
        
        if (message.responses.Length > 0)
        {
            foreach (Response response in message.responses)
            {
                GameObject button = Instantiate(responseButtonPrefab, responseButtons.transform);
                button.GetComponent<DialogueTrigger>().response = response;
                button.GetComponentInChildren<Text>().text = response.reply;
            }
        }
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(message.text)); 
    }

    IEnumerator TypeSentence(string sentence)
    {
        WaitForSeconds wait = new WaitForSeconds(0.03f);
        
        text.text = "";
        foreach (char character in sentence.ToCharArray())
        {
            text.text += character;
            yield return wait; 
        }
    }
    
    private void EndDialog()
    {
        animator.SetBool(IsOpen, false);
    }

    private static DialogueManager _instance;
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    public static DialogueManager Instance { get { return _instance; } }
}
