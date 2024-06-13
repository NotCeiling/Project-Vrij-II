using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class InteractorRanged : MonoBehaviour
{
    private GameObject interactTooltip;
    public float range;
    private bool wasInRange;

    private GameObject player;
    public UnityEvent interact;

    private void Start()
    {
        interactTooltip = GameObject.Find("GameManager").GetComponent<CameraSwapper>().InteractPopup;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < range)
        {
            if (!wasInRange)
            {
                interactTooltip.SetActive(true);
                wasInRange = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
                interact.Invoke();

        }
        else if (wasInRange)
        {
            interactTooltip.SetActive(false);
            wasInRange = false;
        }
    }
}
