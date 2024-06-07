using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlate : MonoBehaviour
{
    private int selected;
    private float zCoord;

    private float leftBorder;
    private float rightBorder;
    private float distanceToLeft = 2;
    private float distanceToRight = 0;

    public int unlocked;


    private void OnMouseDown()
    {
        selected = 1;
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
    }

    private void OnMouseUp()
    {
        selected = 0;
    }

    private void Update()
    {
        if (unlocked == 1)
        {
            if (selected == 1)
            {
                distanceToLeft = Mathf.Clamp(GetMouseWorldPosition().x - leftBorder, 0, 2);
                distanceToRight = Mathf.Clamp(rightBorder - GetMouseWorldPosition().x, 0, 2);

                float targetRotation = Remap(GetMouseWorldPosition().x, rightBorder, leftBorder, 0, 180);
                targetRotation = Mathf.Clamp(targetRotation, 0, 180);
                transform.localRotation = Quaternion.Euler(0, targetRotation, 0);
            }
            else
            {
                leftBorder = GetMouseWorldPosition().x - distanceToLeft;
                rightBorder = GetMouseWorldPosition().x + distanceToRight;
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private float Remap(float value, float startA, float endA, float startB, float endB)
    {
        return (value - startA) / (endA - startA) * (endB - endA) + endA;
    }

}
