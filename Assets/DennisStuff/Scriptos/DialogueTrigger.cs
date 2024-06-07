using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue greeting, phone, knife;

    public GameObject options;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            TriggerDialogueGreeting();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            TriggerDialoguePhone();
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
            TriggerDialogueKnife();

    }


    public void ToggleOptionDisplay()
    {
        if (options.activeSelf)
            options.SetActive(false);
        else
            options.SetActive(true);
    }

    public void TriggerDialogueGreeting()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(greeting);
    }
    public void TriggerDialoguePhone()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(phone);
    }
    public void TriggerDialogueKnife()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(knife);
    }
}
