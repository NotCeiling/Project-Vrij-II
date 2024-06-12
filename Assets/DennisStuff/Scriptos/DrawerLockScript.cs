using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerLockScript : MonoBehaviour
{
    public GameObject[] wheels;
    public GameObject drawer;

    public string code = "1234";

    public GameObject interactionCam;
    public GameObject blockBox;


    public void WheelChangeMade(int newWheelValue)
    {
        CheckCode();
    }

    private void CheckCode()
    {
        string codeAttempt = "";

        foreach (GameObject wheel in wheels)
        {
            codeAttempt += wheel.GetComponent<DrawerLockWheel>().value.ToString();
        }

        if (code == codeAttempt)
            StartCoroutine(OpenDrawer());
    }

    private IEnumerator OpenDrawer()
    {
        for (int i = 0; i <= 40; i++)
        {
            drawer.transform.position = drawer.transform.position + transform.forward * 0.007f;
            interactionCam.transform.position += new Vector3(0, 0.007f, 0.001f);
            interactionCam.transform.Rotate(1.3f, 0f, 0f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
