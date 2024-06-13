using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingKnob : MonoBehaviour
{
    public GameObject lookAtMouse;
    public GameObject puzzleHolder;
    private int selected;

    public int value {get; private set;}
    public int oldValue { get; private set; }



    private void OnMouseDown()
    {
        selected = 1;
        oldValue = value;
    }

    private void OnMouseUp()
    {
        selected = 0;
        puzzleHolder.GetComponent<ElectricityPuzzle>().KnobChangeMade(value, oldValue);
    }

    private void Update()
    {
        if (selected == 1)
        {
            float zCoord = Camera.main.WorldToScreenPoint(transform.position).z;

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = zCoord;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(mousePosition);

            Vector2 direction = new(mousePos.y - transform.position.y, mousePos.z - transform.position.z);

            lookAtMouse.transform.up = direction;

            float angleDifference = lookAtMouse.transform.eulerAngles.z - transform.eulerAngles.z + 90;

            if (angleDifference > 180)
                angleDifference -= 360;

            if (Vector2.Distance(mousePos, transform.position) > 0.08f && angleDifference > 18 && angleDifference < 288)
            {
                RotateCounterClockwise();
            }

            if (Vector2.Distance(mousePos, transform.position) > 0.08f && angleDifference < -18)
            {
                RotateClockwise();
            }
        }
    }


    private void RotateClockwise()
    {
        transform.Rotate(0, 0, -36);
        value++;
        if (value > 9)
            value = 0;
    }

    private void RotateCounterClockwise()
    {
        transform.Rotate(0, 0, 36);
        value--;
        if (value < 0)
            value = 9;
    }

}
