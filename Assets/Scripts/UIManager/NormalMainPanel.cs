using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMainPanel : BasePanel
{
    private static string name = "NormalMainPanel";
    private static string path = "UIPanel/NormalMainPanel";
    public static readonly UIType uIType = new UIType(path, name);

    public NormalMainPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        NormalSceneManager.Instance.LoadUIPanelAfter();
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
