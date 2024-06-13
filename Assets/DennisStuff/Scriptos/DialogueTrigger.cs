using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue1, dialogue2, dialogue3, dialogue4, dialogue5;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject options;
    private GameObject gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager");
    }


    public void ToggleOptionDisplay()
    {
        if (options.activeSelf)
            options.SetActive(false);
        else
            options.SetActive(true);
    }

    public void ChangeTextSource()
    {
        gm.GetComponent<DialogueManager>().nameText = nameText;
        gm.GetComponent<DialogueManager>().dialogueText = dialogueText;
    }

    public void TriggerDialogue1()
    {
        gm.GetComponent<DialogueManager>().StartDialogue(dialogue1);
    }
    public void TriggerDialogue2()
    {
        gm.GetComponent<DialogueManager>().StartDialogue(dialogue2);
    }
    public void TriggerDialogue3()
    {
        gm.GetComponent<DialogueManager>().StartDialogue(dialogue3);
    }
    public void TriggerDialogue4()
    {
        gm.GetComponent<DialogueManager>().StartDialogue(dialogue4);
    }
    public void TriggerDialogue5()
    {
        gm.GetComponent<DialogueManager>().StartDialogue(dialogue5);
    }
}
