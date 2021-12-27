using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CameraScreenshot : MonoBehaviour
{
    [SerializeField]
    int screenshotSizeMultiply = 1;
    public void MakeScreenshot()
    {
        string path = Application.dataPath + "/Resources/Output/";
        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);
        string name = DateTime.Now.ToString()
            .Replace('.', '_')
            .Replace(' ', '_')
            .Replace(':', '_');
        string fileType = ".png";
        ScreenCapture.CaptureScreenshot(path + name + fileType, screenshotSizeMultiply);
    }
}
