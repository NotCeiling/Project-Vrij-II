using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private GameObject cam;

    private void Start()
    {
        cam = Camera.main.gameObject;
    }

    private void Update()
    {
        transform.LookAt(transform.position - (cam.transform.position - transform.position));
    }
}
