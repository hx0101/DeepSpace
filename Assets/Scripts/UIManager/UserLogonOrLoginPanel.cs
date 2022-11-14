using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using SocketGameProtocol;

public class UserLogonOrLoginPanel : BasePanel
{
    private static string name = "UserLogonOrLoginPanel";
    private static string path = "UIPanel/UserLogonOrLoginPanel";
    public static readonly UIType uIType = new UIType(path,name);

    GameObject userPanel;

    LogonRequest logonRequest;
    LoginRequest loginRequest;

    static TMP_InputField username;
    static TMP_InputField password;

    static TMP_Text tips;
    public UserLogonOrLoginPanel() : base(uIType)
    {
    
    }

    public override void OnStart()
    {
        base.OnStart();
        userPanel = GameObject.FindWithTag("UserLogonOrLoginPanel");
        RectTransform rectTransform = userPanel.gameObject.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, -1000, 0);
        rectTransform.DOAnchorPos(new Vector2(0, 0), 1f, false).SetEase(Ease.OutElastic);

        logonRequest = userPanel.gameObject.GetComponent<LogonRequest>();
        loginRequest = userPanel.gameObject.GetComponent<LoginRequest>();

        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "BackButton").onClick.AddListener(Back);
        username = UIMethod.GetInstance().GetOrAddSingleComponentInChild<TMP_InputField>(ActiveObj, "Username");
        password = UIMethod.GetInstance().GetOrAddSingleComponentInChild<TMP_InputField>(ActiveObj, "Password");
        tips = UIMethod.GetInstance().GetOrAddSingleComponentInChild<TMP_Text>(ActiveObj, "Tips");
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Logon").onClick.AddListener(Logon);
        UIMethod.GetInstance().GetOrAddSingleComponentInChild<Button>(ActiveObj, "Login").onClick.AddListener(Login);
    }

    void Back()
    {
        RectTransform rectTransform = userPanel.gameObject.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.DOAnchorPos(new Vector2(0, -1000), 1f, false).SetEase(Ease.InOutQuint);

        Corange corange = GameObject.FindWithTag("Co-range").gameObject.GetComponent<Corange>();
        corange.StartCoroutine(StartPop());
    }

    void Logon()
    {
        tips.text = "";
        if (username.text == "" || password.text == "")
        {
            tips.text = "Username or password cannot be empty!";
            tips.color = new Color(255, 0, 0);
            ClearInputField();
            return;
        }
        logonRequest.SendRequest(username.text,password.text);
    }

    void Login()
    {
        if (username.text == "" || password.text == "")
        {
            tips.text = "Username or password cannot be empty!";
            tips.color = new Color(255, 0, 0);
            ClearInputField();
            return;
        }
        loginRequest.SendRequest(username.text, password.text);
    }

    public static void ShowMessage(MainPack pack)
    {
        tips.text = "";
        switch (pack.Returncode)
        {
            case ReturnCode.Succeed:
                tips.text = "Logon Success,Please Login!";
                tips.color = new Color(0, 255, 0);
                break;
            case ReturnCode.Fail:
                tips.text = "Logon Fail,The user name has been Logon!";
                tips.color = new Color(255, 0, 0);
                break;
            default:
                Debug.Log("def");
                break;
        }

        ClearInputField();
    }

    IEnumerator StartPop()
    {
        yield return new WaitForSeconds(0.4f);
        UIManager.GetInstance().Pop(false);
    }

    static void ClearInputField()
    {
        username.text = "";
        password.text = "";
        tips.alpha = 0;
        tips.DOFade(1, 2);

        Corange corange = GameObject.FindWithTag("Co-range").gameObject.GetComponent<Corange>();
        corange.StartCoroutine(FadeToZero());
    }

    static IEnumerator FadeToZero()
    {
        yield return new WaitForSeconds(2);
        tips.DOFade(0, 2);
    }

    public static void LoginMessage(MainPack pack)
    {
        switch (pack.Returncode)
        {
            case ReturnCode.Succeed:
                ClearInputField();
                UIManager.GetInstance().Pop(false);
                return;
            case ReturnCode.Fail:
                tips.text = "Login Fail!";
                tips.color = new Color(255, 0, 0);
                break;
            default:
                Debug.Log("def");
                break;
        }

        ClearInputField();
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
