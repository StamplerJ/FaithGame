using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text characterName;
    public Text text;

    private Animator animator;
    private Queue<string> sentences;

    private bool isConversationStarted = false;
    
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        animator = GetComponentInChildren<Animator>();
        sentences = new Queue<string>();
    }
    
    public void StartDialog(DialogNode dialog)
    {
        if (!isConversationStarted)
        {
            animator.SetBool(IsOpen, true);
            
            sentences.Clear();

            characterName.text = dialog.name;
            
            foreach (string sentence in dialog.sentences)
            {
                sentences.Enqueue(sentence);
            }

            isConversationStarted = true;
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); 
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
        isConversationStarted = false;
    }

    private static DialogManager _instance;
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    public static DialogManager Instance { get { return _instance; } }
}
