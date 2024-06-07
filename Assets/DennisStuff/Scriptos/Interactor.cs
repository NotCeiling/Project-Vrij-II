using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactor : MonoBehaviour
{
    public GameObject interactTooltip;
    private int inRange;

    public UnityEvent interact;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange == 1)
        {
            interact.Invoke();
            ToggleTooltip();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ToggleTooltip();
        inRange = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        ToggleTooltip();
        inRange = 0;
    }


    private void ToggleTooltip()
    {
        if (interactTooltip.activeSelf)
            interactTooltip.SetActive(false);
        else
            interactTooltip.SetActive(true);
    }
}
