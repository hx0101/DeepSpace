using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;
using UnityEngine.UI;
using TMPro;

public class RoomlistCooperate : MonoBehaviour
{
    public GameObject player;
    public GameObject roomNamePrefab;
    public Image content;
    public void CreateRoomResponse(MainPack pack)
    {
        switch (pack.Returncode)
        {
            case ReturnCode.Succeed:
                Debug.Log("成功");
                UIManager.GetInstance().Pop(true);
                UIManager.GetInstance().Push(new CooperatePanel());
                Destroy(GameObject.FindWithTag("Player"));
                for (int i = 0; i < pack.Playerpack.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        Instantiate(player, new Vector3((int)(i / 2 + 1) * (-3), 1.09f, 0), Quaternion.identity).gameObject.GetComponentInChildren<TMP_Text>().text = pack.Playerpack[i].Playername;
                        continue;
                    }
                    else if (i % 2 == 0)
                    {
                        Instantiate(player, new Vector3(i / 2 * 3, 1.09f, 0), Quaternion.identity).gameObject.GetComponentInChildren<TMP_Text>().text = pack.Playerpack[i].Playername;
                        continue;
                    }
                }
                break;
            case ReturnCode.Fail:
                Debug.Log("失败");
                break;
            default:
                Debug.Log("def");
                break;
        }
    }

    public void SearchRoomResponse(MainPack pack)
    {
        switch (pack.Returncode)
        {
            case ReturnCode.Succeed:
                
                break;
            case ReturnCode.Fail:
                break;
            default:
                Debug.Log("def");
                break;
        }
        UpdateRoomList(pack);
    }

    public void UpdateRoomList(MainPack pack)
    {
        for (int i = 0; i < content.transform.childCount; i++)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }

        int count = -1;
        foreach (RoomPack room in pack.Roompack)
        {
            count++;
            GameObject newRoom = Instantiate(roomNamePrefab, roomNamePrefab.transform.position, Quaternion.identity);
            newRoom.name = room.Roomname;
            newRoom.GetComponentInChildren<TMP_Text>().text = room.Roomname;
            newRoom.transform.SetParent(content.transform);
            newRoom.GetComponentInChildren<Button>().onClick.AddListener(delegate ()
            {
                GameObject.FindWithTag("RoomlistCooperatePanel").gameObject.GetComponent<JoinRequest>().SendRequest(room.Roomname);
               
            });

            RectTransform rectTransform = newRoom.gameObject.GetComponent<RectTransform>();
            rectTransform.anchorMin -= new Vector2(0, 0.1f * count);
            rectTransform.anchorMax -= new Vector2(0, 0.1f * count);

            rectTransform.offsetMin = new Vector2(0, 0);
            rectTransform.offsetMax = new Vector2(0, 0);
            newRoom.SetActive(true);
        }
    }

    public void JoinRoomResponse(MainPack pack)
    {
        switch (pack.Returncode)
        {
            case ReturnCode.Succeed:
                UIManager.GetInstance().Pop(true);
                UIManager.GetInstance().Push(new CooperatePanel());
                Destroy(GameObject.FindWithTag("Player"));
                for (int i = 0; i < pack.Playerpack.Count; i++)
                {
                    if (i % 2 == 1)
                    {
                        Instantiate(player, new Vector3((int)(i / 2 + 1) * (-3), 1.09f, 0), Quaternion.identity).gameObject.GetComponentInChildren<TMP_Text>().text = pack.Playerpack[i].Playername;
                        continue;
                    }
                    else if (i % 2 == 0)
                    {
                        Instantiate(player, new Vector3(i / 2 * 3, 1.09f, 0), Quaternion.identity).gameObject.GetComponentInChildren<TMP_Text>().text = pack.Playerpack[i].Playername;
                        continue;
                    }
                }
                Debug.Log("进入房间");
                break;
            case ReturnCode.Fail:
                break;
            default:
                Debug.Log("def");
                break;
        }
    }
}
