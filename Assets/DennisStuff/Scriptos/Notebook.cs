using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    private bool notesShowing;
    private bool inPosition = true;

    private Rigidbody rb;

    public Vector3 showingPos;
    public Vector3 hiddenPos;
    public Vector3 showingScale;
    public Vector3 hiddenScale;

    private Vector3 targetPos;
    private Vector3 targetScale;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPos = hiddenPos;
        targetScale = hiddenScale;
    }

    private void Update()
    {
        inPosition = (Vector3.Distance(transform.localPosition, targetPos) > 0.01f) ? false : true;

        if (Input.GetKeyDown(KeyCode.X))
        {
            notesShowing = !notesShowing;
            inPosition = false;

            if (notesShowing)
            {
                targetPos = showingPos;
                targetScale = showingScale;
            }
            else
            {
                targetPos = hiddenPos;
                targetScale = hiddenScale;
            }
        }

        if (!inPosition)
        {
            MoveToNewPosition();
        }

    }

    private void MoveToNewPosition()
    {
        var difference = targetPos - transform.localPosition;
        rb.velocity = 10 * difference;

        var sizeDifference = targetScale - transform.localScale;
        transform.localScale = transform.localScale + 0.08f * sizeDifference;
    }



}
