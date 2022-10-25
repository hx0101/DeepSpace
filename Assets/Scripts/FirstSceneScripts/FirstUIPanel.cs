using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstUIPanel : MonoBehaviour
{
    public void StartGame()
    {
        HardScene hardScene = new HardScene();
        SceneControl.GetInstance().LoadScene(hardScene.SceneName,hardScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
