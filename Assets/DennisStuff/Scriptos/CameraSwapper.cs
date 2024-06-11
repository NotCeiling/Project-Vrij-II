using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwapper : MonoBehaviour
{
    public GameObject thirdPersonCam;
    public GameObject interactionCam;
    public GameObject blockBox;

    public GameObject closeCarryPos;
    public GameObject roamingCarryPos;


    public void SmallInteract(GameObject newCam)
    {
        interactionCam = newCam;

        ToggleCam();
        ToggleCarryPos();
    }

    public void Interact(GameObject newCam, GameObject newBlockBox)
    {
        interactionCam = newCam;
        blockBox = newBlockBox;

        ToggleCam();
        ToggleBlockBox();
        ToggleCarryPos();
    }

    private void ToggleCam()
    {
        if (thirdPersonCam.activeSelf)
        {
            interactionCam.SetActive(true);
            thirdPersonCam.SetActive(false);
        }
        else
        {
            interactionCam.SetActive(false);
            thirdPersonCam.SetActive(true);
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
            StartCoroutine(ChangeToRoaming());
        }
        else if (roamingCarryPos.transform.childCount > 0)
        {
            StartCoroutine(ChangeToHolding());
        }
    }


    private IEnumerator ChangeToRoaming()
    {
        closeCarryPos.transform.GetChild(0).GetComponentInChildren<DragObject>().HangPainting(roamingCarryPos);
        yield return new WaitForSeconds(1f);
        roamingCarryPos.transform.GetChild(0).GetComponentInChildren<DragObject>().ToggleRoaming();
    }


    private IEnumerator ChangeToHolding()
    {
        roamingCarryPos.transform.GetChild(0).GetComponentInChildren<DragObject>().HangPainting(closeCarryPos);
        yield return new WaitForSeconds(1f);
        closeCarryPos.transform.GetChild(0).GetComponentInChildren<DragObject>().ToggleRoaming();
    }


}
