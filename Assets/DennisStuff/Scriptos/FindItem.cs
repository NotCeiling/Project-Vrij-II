using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindItem : MonoBehaviour
{
    private GameObject gm;

    public GameObject interactionCam;
    public GameObject blockBox;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void ChangeCam()
    {
        gm.GetComponent<CameraSwapper>().Interact(interactionCam, blockBox);
    }
}
