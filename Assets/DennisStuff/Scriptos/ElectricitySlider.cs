using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricitySlider : MonoBehaviour
{
    private int selected;
    private float zCoord;

    public int value;

    public Transform sliderHandle;
    public GameObject puzzleHolder;


    [SerializeField] private float topBorder;
    [SerializeField] private float bottomBorder;
    [SerializeField] private float distanceToTop = 1;
    [SerializeField] private float distanceToBottom = 0;


    private void OnMouseDown()
    {
        selected = 1;
        zCoord = Camera.main.WorldToScreenPoint(transform.position).z;
    }
    private void OnMouseUp()
    {
        selected = 0;
        CheckValue();
        puzzleHolder.GetComponent<ElectricityPuzzle>().SliderChangeMade();
    }

    private void Update()
    {
        if (selected == 1)
        {
            distanceToTop = Mathf.Clamp(topBorder - GetMouseWorldPosition().y, 0, 1);
            distanceToBottom = Mathf.Clamp(GetMouseWorldPosition().y - bottomBorder, 0, 1);

            float targetPosition = Remap(GetMouseWorldPosition().y, bottomBorder, topBorder, -0.1f, 0.1f);
            targetPosition = Mathf.Clamp(targetPosition, -0.1f, 0.1f);
            sliderHandle.localPosition = new Vector3(0, targetPosition, 0);
        }
        else
        {
            topBorder = GetMouseWorldPosition().y + distanceToTop;
            bottomBorder = GetMouseWorldPosition().y - distanceToBottom;
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
        return (value - startA) / (endA - startA) * (endB - startB) + startB;
    }

    private void CheckValue()
    {
        if (distanceToBottom < 0.25)
            value = 0;
        if (distanceToBottom >= 0.25 && distanceToBottom < 0.5)
            value = 1;
        if (distanceToBottom >= 0.5 && distanceToBottom < 0.75)
            value = 1; 
        if (distanceToBottom >= 0.75)
            value = 0;
    }

}
