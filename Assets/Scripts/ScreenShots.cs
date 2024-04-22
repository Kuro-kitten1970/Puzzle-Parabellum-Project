using System;
using UnityEngine;

public class ScreenShots : MonoBehaviour
{
    public string screenshotFolder = "Screenshots";
    public string screenshotPrefix = "Screenshot";
    public int screenshotNumber = 0;

    string desktopPath = "";

    private void Start()
    {
        desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CaptureScreenshot();
        }
    }

    void CaptureScreenshot()
    {
        string screenshotName = $"{screenshotPrefix}_{screenshotNumber}.png";
        string screenshotPath = System.IO.Path.Combine(desktopPath, screenshotName);

        ScreenCapture.CaptureScreenshot(screenshotPath);

        screenshotNumber++;

        Debug.Log($"Screenshot captured: {screenshotPath}");
    }
}
