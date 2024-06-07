using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingHolder : MonoBehaviour
{
    public GameObject painting;
    private GameObject carryPainting;

    private void Start()
    {
        carryPainting = GameObject.Find("CarryPainting");

        if (transform.childCount > 0)
        {
            painting = transform.GetChild(0).gameObject;
            painting.GetComponent<DragObject>().HangPainting(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (painting != null)
        {
            if (Vector3.Distance(painting.transform.position, transform.position) < 0.1)
                painting.GetComponent<DragObject>().StartDragging();
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (painting == null)
                carryPainting.GetComponent<CarryPaintings>().AttemptHang(gameObject);
            else
                carryPainting.GetComponent<CarryPaintings>().AttemptTake(gameObject);
        }
    }


    public void MovePainting(GameObject newPainting, GameObject newPaintingHolder)
    {
        if (painting != null)
        {
            newPainting.GetComponent<DragObject>().holder.GetComponent<PaintingHolder>().ToHangPainting(painting);
            ToHangPainting(newPainting);
        }
        else
        {
            ToHangPainting(newPainting);
            newPaintingHolder.GetComponent<PaintingHolder>().painting = null;
        }
    }

    public void ToHangPainting(GameObject newPainting)
    {
        painting = newPainting;
        painting.GetComponent<DragObject>().HangPainting(gameObject);
    }

    public void ToTakePainting(Vector3 newPos, GameObject newHolder)
    {
        painting.GetComponent<DragObject>().TakePainting(newPos, newHolder);
        painting = null;
    }
}
