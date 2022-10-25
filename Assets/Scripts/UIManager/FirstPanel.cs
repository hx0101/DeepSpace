using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPanel : BasePanel
{
    private static string name = "FirstPanel";
    private static string path = "UIPanel/FirstPanel";
    public static readonly UIType uIType = new UIType(path, name);

    public FirstPanel() : base(uIType)
    {

    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnStart()
    {
        base.OnStart();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
