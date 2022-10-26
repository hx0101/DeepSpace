using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RoomlistPanel : BasePanel
{
    private static string name = "RoomlistPanel";
    private static string path = "UIPanel/RoomlistPanel";
    public static readonly UIType uIType = new UIType(path, name);

    GameObject Roomlist;

    public RoomlistPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        Roomlist = GameObject.FindWithTag("RoomlistPanel");


        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Back").onClick.AddListener(Back);
    }

    void Back()
    {
        UIManager.GetInstance().Pop(false);
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
