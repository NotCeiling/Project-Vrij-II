using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorLockWheel : MonoBehaviour
{
    public int value { get; private set; }
    private bool interactAllowed = true;

    public GameObject puzzleHolder;


    private void OnMouseDown()
    {
        if (interactAllowed)
        {
            StartCoroutine(Rotate(1));
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && interactAllowed)
        {
            StartCoroutine(Rotate(-1));
        }
    }

    private IEnumerator Rotate(int change)
    {
        interactAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(3f * change, 0f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        interactAllowed = true;
        value += change;

        if (value > 9)
            value = 0;

        if (value < 0)
            value = 9;

        puzzleHolder.GetComponent<DoorLock>().WheelChangeMade(value);
    }

}
