using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SelectPanel : BasePanel
{
    private static string name = "SelectPanel";
    private static string path = "UIPanel/SelectPanel";
    public static readonly UIType uIType = new UIType(path, name);


    public SelectPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();

        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "User").onClick.AddListener(User);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Exit").onClick.AddListener(Exit);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Single").onClick.AddListener(Single);
    }

    void User()
    {
        //弹出User面板
        Debug.Log("弹出User面板");
    }

    void Exit()
    {
        StartScene startScene = new StartScene();
        LoadManager.Instance.LoadNextLevel(startScene.SceneName, startScene);
    }

    void Single()
    {

    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }
}
