﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class SelectPanel : BasePanel
{
    private static string name = "SelectPanel";
    private static string path = "UIPanel/SelectPanel";
    public static readonly UIType uIType = new UIType(path, name);

    Button single;
    Button multiple;
    Button back;
    Button simple;
    Button normal;
    Button difficult;
    Button compete;
    Button cooperate;

    SelectPanelTransform selectPanelTransform; 
    public SelectPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        base.OnStart();
        selectPanelTransform = GameObject.FindWithTag("SelectPanel").gameObject.GetComponent<SelectPanelTransform>();

        single = UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Single");
        multiple = UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Multiple");
        back = UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Back");
        simple = UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Simple");
        normal = UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Normal");
        difficult = UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Difficult");
        compete = UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Compete");
        cooperate = UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Cooperate");

        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "User").onClick.AddListener(User);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Exit").onClick.AddListener(Exit);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Single").onClick.AddListener(Single);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Multiple").onClick.AddListener(Multiple);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Back").onClick.AddListener(Back);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Simple").onClick.AddListener(Simple);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Normal").onClick.AddListener(Normal);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Difficult").onClick.AddListener(Difficult);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Compete").onClick.AddListener(Compete);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Cooperate").onClick.AddListener(Cooperate);
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
        selectPanelTransform.GameModelExitGet();
        selectPanelTransform.DifficultyEnterGet();
    }

    void Multiple()
    {
        selectPanelTransform.GameModelExitGet();
        selectPanelTransform.AOrTogetherEnterGet();
    }

    void Back()
    {
        if (simple.enabled)
        {
            selectPanelTransform.DifficultyExitGet();
        }
        else
        {
            selectPanelTransform.AOrTogetherExitGet();
        }
        selectPanelTransform.GameModelEnterGet();
    }

    void Simple()
    {

    }

    void Normal()
    {

    }

    void Difficult()
    {
        HardScene hardScene = new HardScene();
        LoadManager.Instance.LoadNextLevel(hardScene.SceneName,hardScene);
    }

    void Compete()
    {
        if (simple.enabled)
        {
            selectPanelTransform.DifficultyExitGet();
        }
        else
        {
            selectPanelTransform.AOrTogetherExitGet();
        }
        selectPanelTransform.StartCoroutine(LoadRoomlistPanel());
    }

    void Cooperate()
    {

    }

    IEnumerator LoadRoomlistPanel()
    {
        yield return new WaitForSeconds(1.5f);
        UIManager.GetInstance().Push(new RoomlistPanel());
    }
    public override void OnEnable()
    {
        base.OnEnable();
        selectPanelTransform.AOrTogetherEnterGet();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }

    public override void OnDisable()
    {
        
    }

    public override void OnDestroy()
    {
        
    }
}
