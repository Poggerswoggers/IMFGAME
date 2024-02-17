using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagment : MonoBehaviour
{
    [SerializeField] GameObject zoomCam;
    [SerializeField] Camera normalCam;
    bool zoom;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            zoom = !zoom;
            zoomCam.SetActive(zoom);
        }
    }
}
