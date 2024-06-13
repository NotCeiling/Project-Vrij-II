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

    public GameObject InteractPopup;


    public void SmallInteract(GameObject newCam)
    {
        interactionCam = newCam;

        ToggleCam();
        //ToggleCarryPos();
    }

    public void Interact(GameObject newCam, GameObject newBlockBox)
    {
        interactionCam = newCam;
        blockBox = newBlockBox;

        ToggleCam();
        StartCoroutine(ToggleBlockBox());
        //ToggleRoamingMode();
    }

    public void ToggleCam()
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


    private IEnumerator ToggleBlockBox()
    {
        if (blockBox.activeSelf)
        {
            yield return new WaitForSeconds(1); 
            blockBox.SetActive(false);
        }
        else
        {
            blockBox.SetActive(true);
        }
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

    private void ToggleRoamingMode()
    {
        closeCarryPos.transform.GetChild(0).GetComponentInChildren<DragObject>().ToggleRoaming();
    }

}
