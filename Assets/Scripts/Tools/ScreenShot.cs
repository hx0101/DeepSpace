using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    bool grab;
    private void Awake()
    {
        grab = true;
    }
    private void OnPostRender()
    {
        if (grab)
        {
            Texture2D texture2D = new Texture2D(Screen.width,Screen.height);
            texture2D.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            texture2D.Apply();
            byte[] bytes = texture2D.EncodeToPNG();

            string filename = Application.dataPath + "/Screenshot.png";
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log(string.Format("截取一张图片：{0}", filename));
            grab = false;
        }
    }
}
