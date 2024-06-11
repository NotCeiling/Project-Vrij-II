using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DoorLock : MonoBehaviour
{
    public GameObject[] wheels;
    public GameObject door;

    private GameObject gm;

    public string cardName;
    public string code = "1234";
    private bool unlocked;
    private bool doorIsOpen;
    private bool interactAllowed = true;

    public GameObject interactionCam;
    public GameObject blockBox;


    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void WheelChangeMade(int newWheelValue)
    {
        CheckCode();
    }

    private void CheckCode()
    {
        string codeAttempt = "";

        foreach (GameObject wheel in wheels)
        {
            codeAttempt += wheel.GetComponent<DoorLockWheel>().value.ToString();
        }

        if (code == codeAttempt)
            unlocked = true;
        else
            unlocked = false;
    }

    public void AttemptOpenDoor()
    {

        if (unlocked || gm.GetComponent<Inventory>().CheckForItem(cardName))
        {
            if (interactAllowed)
            {
                if (doorIsOpen)
                    StartCoroutine(RotateDoor(1));
                else
                    StartCoroutine(RotateDoor(-1));
            }
        }
        else
        {
            gm.GetComponent<CameraSwapper>().Interact(interactionCam, blockBox);
        }
    }

    private IEnumerator RotateDoor(int change)
    {
        interactAllowed = false;

        if (doorIsOpen)
            doorIsOpen = false;
        else
            doorIsOpen = true;

        for (int i = 0; i <= 20; i++)
        {
            door.transform.Rotate(0f, 4f * change, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        interactAllowed = true;
    }

    

}
