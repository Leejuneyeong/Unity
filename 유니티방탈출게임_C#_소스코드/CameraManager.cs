using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera MainCamera;
    public Camera SubCamera;
    // Start is called before the first frame update
    public void Start()
    {
        mainCameraOn();
    }
    public void mainCameraOn()
    {
        MainCamera.enabled = true;
        SubCamera.enabled = false;
    }

    public void subCameraOn()
    {
        MainCamera.enabled = false;
        SubCamera.enabled = true;
    }
    void Update()
    {
        if (Input.GetKey("1"))
        {
            subCameraOn();
        }
        if (Input.GetKey("2"))
        {
            mainCameraOn();
        }
    }
}
