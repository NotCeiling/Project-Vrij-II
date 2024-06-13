using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Interactor : MonoBehaviour
{
    private GameObject interactTooltip;
    private int inRange;

    public UnityEvent interact;

    private void Start()
    {
        interactTooltip = GameObject.Find("GameManager").GetComponent<CameraSwapper>().InteractPopup;
    }

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
        interactTooltip.SetActive(true);
        inRange = 1;
    }

    private void OnTriggerExit(Collider other)
    {
        interactTooltip.SetActive(false);
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
