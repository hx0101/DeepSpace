using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScene : SceneBase
{
    public readonly string SceneName = "SimpleScene";

    public override void EnterScene()
    {
        SimpleSceneManager.Instance.LoadSceneAfter();
        SimpleMainPanel simpleMainPanel = new SimpleMainPanel();
        LoadManager.Instance.LoadNextPanel(simpleMainPanel);
    }

    public override void ExitScene()
    {
    }
}
