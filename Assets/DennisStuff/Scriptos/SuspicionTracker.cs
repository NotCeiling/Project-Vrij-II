using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuspicionTracker : MonoBehaviour
{


    public static float zackTimer, timTimer, deanTimer, fridayTimer, alisonTimer;
    public string primeSuspect;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            zackTimer = 0;
            timTimer = 0;
            deanTimer = 0;
            fridayTimer = 0;
            alisonTimer = 0;
        }
    }

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

    public void EndInvestigation()
    {
        SceneManager.LoadScene("EndScene");
    }

}
