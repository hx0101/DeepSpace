using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class Roomlist : MonoBehaviourPunCallbacks
{
    public GameObject roomNamePrefab;

    public Image content;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("RoomListOne");
        if (transform != null)
        {
            foreach (var gObj in gameObjects)
            {
                Destroy(gObj);
            }
        }
        
        int count = -1;
        foreach (var room in roomList)
        {
            if (room.PlayerCount == 0)
            {
                roomList.Remove(room);
            }
            count++;
            GameObject newRoom = Instantiate(roomNamePrefab, roomNamePrefab.transform.position, Quaternion.identity); 
            newRoom.name = room.Name;
            newRoom.GetComponentInChildren<TMP_Text>().text = room.Name;
            newRoom.transform.SetParent(content.transform);
            newRoom.GetComponentInChildren<Button>().onClick.AddListener(delegate()
            {
                UIManager.GetInstance().Pop(true);
                UIManager.GetInstance().Push(new LoadingPanel());
                PhotonNetwork.JoinRoom(room.Name);
            });

            RectTransform rectTransform = newRoom.gameObject.GetComponent<RectTransform>();
            rectTransform.anchorMin -= new Vector2(0, 0.1f * count);
            rectTransform.anchorMax -= new Vector2(0, 0.1f * count);

            rectTransform.offsetMin = new Vector2(0, 0);
            rectTransform.offsetMax = new Vector2(0, 0);
            newRoom.SetActive(true);
        }
    }
}
