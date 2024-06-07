using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    public GameObject[] wheels;
    public GameObject door;

    public string code = "1234";


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
        {
            Debug.Log("Door is open!");
        }
    }

}
