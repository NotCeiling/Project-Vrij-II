using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspicionTracker : MonoBehaviour
{
    public static float zackTimer, timTimer, deanTimer, fridayTimer, alisonTimer;
    public string primeSuspect;



    private void FixedUpdate()
    {
        switch (primeSuspect)
        {
            case "Zack":
                zackTimer += Time.fixedDeltaTime;
                break;
            case "Tim":
                timTimer += Time.fixedDeltaTime;
                break;
            case "Dean":
                deanTimer += Time.fixedDeltaTime;
                break;
            case "Friday":
                fridayTimer += Time.fixedDeltaTime;
                break;
            case "Alison":
                alisonTimer += Time.fixedDeltaTime;
                break;
            default:
                break;
        }
    }

    public void ChangeSuspect(string newSuspect)
    {
        primeSuspect = newSuspect;
    }

}
