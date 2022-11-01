using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CompetePanel : BasePanel
{
    private static string name = "CompetePanel";
    private static string path = "UIPanel/CompetePanel";
    public static readonly UIType uIType = new UIType(path, name);

    Launcher launcher;
    public CompetePanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        launcher = GameObject.FindWithTag("NetworkLauncher").gameObject.GetComponent<Launcher>();

        Button start = UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Start");
        if (PhotonNetwork.IsMasterClient)
        {
            start.onClick.AddListener(Start);
        }
        else
        {
            start.GetComponentInChildren<TMP_Text>().alpha = 0.5f;
            start.enabled = false;
        }
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Back").onClick.AddListener(Back);
    }

    void Start()
    {
        launcher.LoadLevel();
    }

    void Back()
    {
        launcher.LeaveRoom();
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
