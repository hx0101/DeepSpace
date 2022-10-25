using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelect : SceneBase
{
    public readonly string SceneName = "GameSelect";

    public override void EnterScene()
    {
        SelectPanel selectPanel = new SelectPanel();
        LoadManager.Instance.LoadNextPanel(selectPanel);
    }

    public override void ExitScene()
    {

    }
}
