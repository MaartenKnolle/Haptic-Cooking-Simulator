using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenShotTaker : MonoBehaviour
{
    public KeyCode takeScreenshotKey = KeyCode.P;
    public string title = "screenshot";
    public int screenshotCount = 0;
    public int superSize = 4;

    private void Start()
    {
        string fname = "Screenshots/" + title + "_" + screenshotCount + "_" + Screen.width + "X" + Screen.height + "" + ".png";
        while (File.Exists(fname))
        {
            screenshotCount++;
            fname = "Screenshots/" + title + "_" + screenshotCount + "_" + Screen.width + "X" + Screen.height + "" + ".png";
        }
        Debug.Log("screenshotCount set to " + screenshotCount);
    }

    private void Update()
    {
        string fname = "Screenshots/" + title + "_" + screenshotCount + "_" + Screen.width + "X" + Screen.height + "" + ".png";

        if (Input.GetKeyDown(takeScreenshotKey))
        {
            //StartCoroutine(captureScreenshot2());
            ScreenCapture.CaptureScreenshot(fname, superSize);
            Debug.Log("Screenshot taken.");
            screenshotCount++;
        }
    }

    IEnumerator captureScreenshot2()
    {
        yield return new WaitForEndOfFrame();
        string path = "Screenshots/"
                 + "_" + screenshotCount + "_" + Screen.width + "X" + Screen.height + "" + ".jpeg";

        Texture2D screenImage = new Texture2D(Screen.width, Screen.height);
        //Get Image from screen
        screenImage.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        screenImage.Apply();
        //Convert to png
        byte[] imageBytes = screenImage.EncodeToPNG();

        //Save image to file
        System.IO.File.WriteAllBytes(path, imageBytes);
        Debug.Log("Screenshot taken.");
    }
}
