using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;

public class GameFace : MonoBehaviour
{
    private ClientManager clientManager;
    private RequestManager requestManager;

    private static GameFace face;
    public static GameFace Face
    {
        get
        {
            if (face == null)
            {
                face= GameObject.Find("GameFace").GetComponent<GameFace>();
            }
            return face;
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        clientManager = new ClientManager(this);
        requestManager = new RequestManager(this);

        clientManager.OnInit();
        requestManager.OnInit();
        
    }

    private void OnDestroy()
    {
        clientManager.OnDestroy();
        requestManager.OnDestroy();
    }

    private void Update()
    {
        
    }


    public void Send(MainPack pack)
    {
        clientManager.Send(pack);
    }

    public void HandleResponse(MainPack pack)
    {
        //处理
        requestManager.HandleResponse(pack);
        //Debug.Log("face处理");
    }

    public void AddRequest(BaseRequest request)
    {
        requestManager.AddRequest(request);
    }

    public void RemoveRequest(ActionCode action)
    {
        requestManager.RemoveRequest(action);
    }

    public void ShowMessage(MainPack pack)
    {
        UserLogonOrLoginPanel.ShowMessage(pack);
    }

    public void LoginMessage(MainPack pack)
    {
        UserLogonOrLoginPanel.LoginMessage(pack);
    }

    public void CreateRoom(MainPack pack)
    {
        GameObject.FindWithTag("RoomlistCooperatePanel").gameObject.GetComponent<RoomlistCooperate>().CreateRoomResponse(pack);
    }

    public void SearchRoom(MainPack pack)
    {
        GameObject.FindWithTag("RoomlistCooperatePanel").gameObject.GetComponent<RoomlistCooperate>().SearchRoomResponse(pack);
    }

    public void JoinRoom(MainPack pack)
    {
        GameObject.FindWithTag("RoomlistCooperatePanel").gameObject.GetComponent<RoomlistCooperate>().JoinRoomResponse(pack);
    }

    public void ExitRoom(MainPack pack)
    {
        GameObject.FindWithTag("CooperatePanel").gameObject.GetComponent<CooperatePanelResponse>().ExitRoomResponse(pack);
    }

    public void OtherPlayerChange(MainPack pack)
    {
        GameObject.FindWithTag("CooperatePanel").gameObject.GetComponent<CooperatePanelResponse>().OtherPlayerChange(pack);
    }

    public void ChatResponse(string str)
    {
        GameObject.FindWithTag("CooperatePanel").gameObject.GetComponent<CooperatePanelResponse>().ChatResponse(str);
    }

    public void StartGameResponse(MainPack pack)
    {
        GameObject.FindWithTag("CooperatePanel").gameObject.GetComponent<CooperatePanelResponse>().StartGameResponse(pack);
    }
}
