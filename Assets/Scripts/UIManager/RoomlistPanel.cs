using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class RoomlistPanel : BasePanel
{
    private static string name = "RoomlistPanel";
    private static string path = "UIPanel/RoomlistPanel";
    public static readonly UIType uIType = new UIType(path, name);

    GameObject Roomlist;

    SelectPanelTransform selectPanelTransform;

    Launcher launcher;

    TMP_Text inputText;
    public RoomlistPanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        Roomlist = GameObject.FindWithTag("RoomlistPanel");
        selectPanelTransform = GameObject.FindWithTag("SelectPanel").gameObject.GetComponent<SelectPanelTransform>();
        launcher = GameObject.FindWithTag("NetworkLauncher").gameObject.GetComponent<Launcher>();
        RectTransform rectTransform = Roomlist.gameObject.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -1000, 0);
        rectTransform.DOAnchorPos(new Vector2(0, 0), 1f, false).SetEase(Ease.OutElastic);

        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Back").onClick.AddListener(Back);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Search").onClick.AddListener(Search);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Create").onClick.AddListener(Create);
    }

    void Back()
    {
        selectPanelTransform.AOrTogetherEnterGet();
        RectTransform rectTransform = Roomlist.gameObject.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.DOAnchorPos(new Vector2(0, -1000), 1f, false).SetEase(Ease.InOutQuint);

        Corange corange = GameObject.FindWithTag("Co-range").gameObject.GetComponent<Corange>();
        corange.StartCoroutine(StartPop());
    }

    void Search()
    {
        inputText = UIMethod.GetInstance().GetOrAddSingleComponentInChild<TMP_Text>(ActiveObj, "InputText");
        if (inputText.text != null)
        {
            launcher.SearchRoom(inputText.text);
        }
    }

    void Create()
    {
        inputText = UIMethod.GetInstance().GetOrAddSingleComponentInChild<TMP_Text>(ActiveObj, "InputText");
        if (inputText.text.Length > 1 && inputText.text.Length < 8)
        {
            UIManager.GetInstance().Pop(true);
            UIManager.GetInstance().Push(new LoadingPanel());
            launcher.CreateRoom(inputText.text);
        }
    }

    IEnumerator StartPop()
    {
        yield return new WaitForSeconds(0.6f);
        UIManager.GetInstance().Pop(false);
        launcher.DisconnectServer();
    }

    public override void OnEnable()
    {

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
