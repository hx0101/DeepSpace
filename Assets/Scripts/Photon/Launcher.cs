using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject roomNamePrefab;

    GameObject selectPanel;
    GameObject roomlistPanel;
    // Start is called before the first frame update
    void Start()
    {
        
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
        foreach (var room in MyList.RoomNames)
        {
            if (room == roomName)
            {
                return;
            }
        }
        PhotonNetwork.CreateRoom(roomName, options, default);
        MyList.RoomNames.Add(roomName);
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
        PhotonNetwork.LoadLevel(3);
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
        base.OnJoinedRoom();
        
        switch(PhotonNetwork.CurrentRoom.PlayerCount)
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

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        UIManager.GetInstance().Pop(true);
        UIManager.GetInstance().Push(new SelectPanel());
        UIManager.GetInstance().Push(new RoomlistPanel());
    }
}
