using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject roomNamePrefab;

    GameObject selectPanel;
    GameObject roomlistPanel;

    bool IsStartGame;
    byte eve;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;

        eve = 0;
        IsStartGame = false;
    }

    private void OnDisable()
    {
        PhotonNetwork.AutomaticallySyncScene = false;
    }

    public void GetCompeteButtonDown()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void PlayerEnterLobby()
    {
        selectPanel = GameObject.FindWithTag("SelectPanel");
        roomlistPanel = GameObject.FindWithTag("RoomlistPanel");
        PhotonNetwork.NickName = UIMethod.GetInstance().GetOrAddSingleComponentInChild<TMP_Text>(selectPanel, "UserName").text;
    }

    public void CreateRoom(string roomName)
    {
        RoomOptions options = new RoomOptions { MaxPlayers = 5 };
        List<RoomInfo> roomlist = new List<RoomInfo>();
        foreach (var room in roomlist)
        {
            if (room.Name == roomName)
            {
                return;
            }
        }
        UIManager.GetInstance().Pop(true);
        UIManager.GetInstance().Push(new LoadingPanel());
        PhotonNetwork.CreateRoom(roomName, options, default);
    }

    public void RefreshList()
    {
        Image content = UIMethod.GetInstance().GetOrAddSingleComponentInChild<Image>(roomlistPanel, "Content");
        int count = -1;
        foreach (var room in MyList.RoomNames)
        {
            count++;
            GameObject newRoom = Instantiate(roomNamePrefab, roomNamePrefab.transform.position,Quaternion.identity);
            newRoom.name = room;
            newRoom.GetComponentInChildren<TMP_Text>().text = room;
            newRoom.transform.SetParent(content.transform);

            RectTransform rectTransform = newRoom.GetComponent<RectTransform>();
            rectTransform.anchorMin -= new Vector2(0, 0.1f * count);
            rectTransform.anchorMax -= new Vector2(0, 0.1f * count);

            rectTransform.offsetMin = new Vector2(0, 0);
            rectTransform.offsetMax = new Vector2(0, 0);
            newRoom.SetActive(true);
        }
    }

    public void SearchRoom(string roomName)
    {
        List<RoomInfo> roomList = new List<RoomInfo>();
        
        foreach (var room in roomList)
        {
            if (roomName == room.Name)
            {
                
            }
        }
    }

    public void LoadLevel()
    {
        eve = 1;
        Compete compete = new Compete();
        LoadManager.Instance.LoadNextLevel(compete.SceneName, compete,false);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void DisconnectServer()
    {
        PhotonNetwork.Disconnect();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("成功");

        //进入游戏大厅
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("进入房间");
        base.OnJoinedRoom();

        if(!IsStartGame)
        {
            switch (PhotonNetwork.CurrentRoom.PlayerCount)
            {
                case 1:
                    break;
                case 2:
                    PhotonNetwork.Instantiate("Player", new Vector3(-3, 1.09f, 0), Quaternion.identity, 0);
                    break;
                case 3:
                    PhotonNetwork.Instantiate("Player", new Vector3(3, 1.09f, 0), Quaternion.identity, 0);
                    break;
                case 4:
                    PhotonNetwork.Instantiate("Player", new Vector3(-6, 1.09f, 0), Quaternion.identity, 0);
                    break;
                case 5:
                    PhotonNetwork.Instantiate("Player", new Vector3(6, 1.09f, 0), Quaternion.identity, 0);
                    break;
            }

            UIManager.GetInstance().Pop(true);
            UIManager.GetInstance().Push(new CompetePanel());
        }    
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        UIManager.GetInstance().Pop(true);
        SelectPanel selectPanel = new SelectPanel();
        selectPanel.loadGameModel = false;
        UIManager.GetInstance().Push(selectPanel);
        UIManager.GetInstance().Push(new RoomlistPanel());
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.RaiseEvent(eve, new byte[] { }, null, ExitGames.Client.Photon.SendOptions.SendReliable);
        }
    }

    public void OnEvent(EventData photonEvent)
    {
        Debug.Log(photonEvent.Code);
        if (photonEvent.Code == 1)
        {
            IsStartGame = true;
        }
    }
}
