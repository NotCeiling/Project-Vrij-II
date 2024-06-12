using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MovablePlank : MonoBehaviour
{

    private bool interactAllowed = true;
    private bool up;

    private void OnMouseDown()
    {
        if (interactAllowed)
        {
            if (up)
            {
                StartCoroutine(MovePlank(-1));
                up = false;
            }
            else
            {
                StartCoroutine(MovePlank(1));
                up = true;
            }
        }
    }

    private IEnumerator MovePlank(int change)
    {
        interactAllowed = false;

        for (int i = 0; i <= 30; i++)
        {
            transform.position += new Vector3(0, 0.03f * change, 0);
            yield return new WaitForSeconds(0.01f);
        }

        interactAllowed = true;
    }
}
