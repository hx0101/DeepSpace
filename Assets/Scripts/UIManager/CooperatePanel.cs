using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooperatePanel : BasePanel
{
    private static string name = "CooperatePanel";
    private static string path = "UIPanel/CooperatePanel";
    public static readonly UIType uIType = new UIType(path, name);

    TMP_InputField chatMessages;

    RoomExitRequest roomExitRequest;
    ChatRequest chatRequest;
    StartGameRequest startGameRequest;
    public CooperatePanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        chatMessages = UIMethod.GetInstance().GetOrAddSingleComponentInChild<TMP_InputField>(ActiveObj, "ChatMessages");
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Send").onClick.AddListener(Send);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Start").onClick.AddListener(Start);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Back").onClick.AddListener(Back);

        GameObject cooperatePanel = GameObject.FindWithTag("CooperatePanel");
        roomExitRequest = cooperatePanel.gameObject.GetComponent<RoomExitRequest>();
        chatRequest = cooperatePanel.gameObject.GetComponent<ChatRequest>();
        startGameRequest = cooperatePanel.gameObject.GetComponent<StartGameRequest>();
        base.OnStart();
        
    }

    void Send()
    {
        if (chatMessages.text != "")
        {
            chatRequest.SendRequest(chatMessages.text);
            chatMessages.text = "";
        }
    }

    void Start()
    {
        startGameRequest.SendRequest();
    }

    void Back()
    {
        roomExitRequest.SendRequest();
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
