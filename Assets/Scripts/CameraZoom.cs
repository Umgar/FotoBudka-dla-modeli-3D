using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    float maxCameraZoom = -2;
    [SerializeField]
    float minCameraZoom = -15;

    // Update is called once per frame
    void LateUpdate()
    {
        float scrollWhell = Input.GetAxis("Mouse ScrollWheel");
        if(scrollWhell != 0)
        {
            scrollWhell = Camera.main.transform.position.z + scrollWhell;
            if(scrollWhell > maxCameraZoom)
                scrollWhell = maxCameraZoom;
            if(scrollWhell < minCameraZoom)
                scrollWhell = minCameraZoom;
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,
                                                         Camera.main.transform.position.y,
                                                         scrollWhell);
        }
    }
}
