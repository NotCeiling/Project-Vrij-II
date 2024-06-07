using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwapper : MonoBehaviour
{
    public GameObject originalCam;
    public GameObject otherCam;
    public GameObject blockBox;

    public GameObject closeCarryPos;
    public GameObject roamingCarryPos;


    public void Interact()
    {
        ToggleCam();
        ToggleBlockBox();
        ToggleCarryPos();
    }

    private void ToggleCam()
    {
        if (originalCam.activeSelf)
        {
            otherCam.SetActive(true);
            originalCam.SetActive(false);
        }
        else
        {
            otherCam.SetActive(false);
            originalCam.SetActive(true);
        }
    }

    private void ToggleBlockBox()
    {
        if (blockBox.activeSelf)
            blockBox.SetActive(false);
        else
            blockBox.SetActive(true);
    }

    private void ToggleCarryPos()
    {
        if (closeCarryPos.transform.childCount > 0)
        {
            closeCarryPos.transform.GetChild(0).GetComponentInChildren<DragObject>().HangPainting(roamingCarryPos);
            closeCarryPos.transform.GetChild(0).GetComponentInChildren<DragObject>().ToggleRoaming();
        }
        else if (roamingCarryPos.transform.childCount > 0)
        {
            roamingCarryPos.transform.GetChild(0).GetComponentInChildren<DragObject>().HangPainting(closeCarryPos);
            closeCarryPos.transform.GetChild(0).GetComponentInChildren<DragObject>().ToggleRoaming();
        }
    }
}
