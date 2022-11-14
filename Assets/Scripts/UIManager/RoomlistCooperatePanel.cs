using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using SocketGameProtocol;

public class RoomlistCooperatePanel : BasePanel
{
    private static string name = "RoomlistCooperatePanel";
    private static string path = "UIPanel/RoomlistCooperatePanel";
    public static readonly UIType uIType = new UIType(path, name);

    GameObject RoomlistCooperate;

    SelectPanelTransform selectPanelTransform;

    TMP_Text inputText;

    CreateRoomRequest createRoomRequest;
    SearchRoomRequest searchRoomRequest;
    public RoomlistCooperatePanel() : base(uIType)
    {

    }

    public override void OnStart()
    {
        RoomlistCooperate = GameObject.FindWithTag("RoomlistCooperatePanel");
        selectPanelTransform = GameObject.FindWithTag("SelectPanel").gameObject.GetComponent<SelectPanelTransform>();
        RectTransform rectTransform = RoomlistCooperate.gameObject.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -1000, 0);
        rectTransform.DOAnchorPos(new Vector2(0, 0), 1f, false).SetEase(Ease.OutElastic);

        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Back").onClick.AddListener(Back);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Search").onClick.AddListener(Search);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Create").onClick.AddListener(Create);

        createRoomRequest = RoomlistCooperate.gameObject.GetComponent<CreateRoomRequest>();
        searchRoomRequest = RoomlistCooperate.gameObject.GetComponent<SearchRoomRequest>();
    }

    void Back()
    {
        selectPanelTransform.AOrTogetherEnterGet();
        RectTransform rectTransform = RoomlistCooperate.gameObject.GetComponent<RectTransform>();
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
            searchRoomRequest.SendRequest();
        }
    }

    void Create()
    {
        inputText = UIMethod.GetInstance().GetOrAddSingleComponentInChild<TMP_Text>(ActiveObj, "InputText");
        if (inputText.text.Length > 1 && inputText.text.Length < 8)
        {
            createRoomRequest.SendRequest(inputText.text, 5);
        }
    }

    IEnumerator StartPop()
    {
        yield return new WaitForSeconds(0.6f);
        UIManager.GetInstance().Pop(false);
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
