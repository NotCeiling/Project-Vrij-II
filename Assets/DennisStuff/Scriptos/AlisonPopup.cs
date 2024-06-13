using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlisonPopup : MonoBehaviour
{
    private float timer;
    private bool counting;

    public UnityEvent finish;

    private void FixedUpdate()
    {
        if (counting)
        timer += Time.fixedDeltaTime;

        if (timer > 10)
        {
            finish.Invoke();
            Destroy(this);
        }
    }

    public void StartTimer()
    {
        counting = true;
    }

}
