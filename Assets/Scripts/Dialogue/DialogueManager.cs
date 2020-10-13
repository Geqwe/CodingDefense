using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // public Text nameText;
    public Text dialogueText; 
    private Queue<string> sentences;
    private Dialogue dialog;
    public GameObject dialogueBox;
    bool activeSpace = true;
    string sentenceHere = "";
    public GameObject playButton;
    public GameObject exerciseBox;

    // Start is called before the first frame update
    void Start()
    {
        if(sentences==null) {
            sentences = new Queue<string>();
        }
    }

    public void StartDialogue(Dialogue dialogue) {
        // sentences.Clear();
        if(playButton!=null) {
            playButton.SetActive(false);
        }
        if(sentences==null) {
            sentences = new Queue<string>();
        }
        dialogueBox.SetActive(true);
        activeSpace = true;
        dialog = dialogue;
        // Debug.Log(dialogue.sentences[0]);
        // Debug.Log(dialog.sentences[1]);
        // nameText.text = "";
        sentenceHere = "";
        dialogueText.text = "";

        for (int i=0;i<dialogue.sentences.Length;i++)
        {
            sentences.Enqueue(dialogue.sentences[i]);
        }
    }

    public void StartDialogueAgain() {
        sentences.Clear();
        sentenceHere = "";
        dialogueText.text = "";
        for (int i=0;i<dialog.sentences.Length;i++)
        {
            sentences.Enqueue(dialog.sentences[i]);
        }
    }

    public void DisplayNextSentence() {
        // if(nameText.text == dialog.names[0]) {
        //     nameText.text = dialog.names[1];
        // }
        // else if(nameText.text == "") {
        //     nameText.text = dialog.names[0];
        // }
        // else {
        //     nameText.text = dialog.names[0];
        // }

        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }

        sentenceHere = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentenceHere));
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue() {
        dialogueBox.SetActive(false);
        activeSpace = false;
        Debug.Log("End of conversation");
        if(playButton!=null) {
            playButton.SetActive(true);
        }
        exerciseBox.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space") && activeSpace==true) {
            DisplayNextSentence();
        }
    }
}
