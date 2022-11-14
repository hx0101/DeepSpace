using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMainPanel : BasePanel
{
    private static string name = "SimpleMainPanel";
    private static string path = "UIPanel/SimpleMainPanel";
    public static readonly UIType uIType = new UIType(path, name);

    public SimpleMainPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        SimpleSceneManager.Instance.LoadUIPanelAfter();
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
