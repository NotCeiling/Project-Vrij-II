using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryPaintings : MonoBehaviour
{
    public GameObject paintingInHand;
    public GameObject carryPos;


    public void AttemptHang(GameObject holder)
    {
        if (paintingInHand != null)
        {
            holder.GetComponent<PaintingHolder>().ToHangPainting(paintingInHand);
            paintingInHand = null;
        }
    }

    public void AttemptTake(GameObject holder)
    {
        if (paintingInHand == null)
        {
            paintingInHand = holder.GetComponent<PaintingHolder>().painting;
            holder.GetComponent<PaintingHolder>().ToTakePainting(carryPos.transform.position, carryPos.gameObject);
        }
        else
        {
            GameObject wasInHand = paintingInHand;
            paintingInHand = holder.GetComponent<PaintingHolder>().painting;
            holder.GetComponent<PaintingHolder>().ToTakePainting(carryPos.transform.position, gameObject);
            holder.GetComponent<PaintingHolder>().ToHangPainting(wasInHand);
        }
    }
}
