using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalScene : SceneBase
{
    public readonly string SceneName = "NormalScene";

    public override void EnterScene()
    {
        NormalSceneManager.Instance.LoadSceneAfter();
        NormalMainPanel normalMainPanel = new NormalMainPanel();
        LoadManager.Instance.LoadNextPanel(normalMainPanel);
    }

    public override void ExitScene()
    {
    }
}
