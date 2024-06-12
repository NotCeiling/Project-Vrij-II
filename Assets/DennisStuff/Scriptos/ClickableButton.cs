using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class ClickableButton : MonoBehaviour
{
    public UnityEvent button;

    private bool interactAllowed = true;
    private bool pressed = false;

    private void OnMouseDown()
    {
        if (interactAllowed)
        {
            button.Invoke();

            if (pressed)
            {
                StartCoroutine(Push(-1));
                pressed = false;
            }
            else
            {
                StartCoroutine(Push(1));
                pressed = true;
            }
        }
    }


    private IEnumerator Push(int change)
    {
        interactAllowed = false;

        for (int i = 0; i <= 10; i++)
        {
            transform.position = transform.position + transform.forward * 0.0012f * change;
            yield return new WaitForSeconds(0.01f);
        }

        interactAllowed = true;
    }

}
