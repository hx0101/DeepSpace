using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;
using TMPro;
using UnityEngine.UI;

public class CooperatePanelResponse : MonoBehaviour
{
    public GameObject player;

    public GameObject chatOne;

    public GameObject content;

    public void ExitRoomResponse(MainPack pack)
    {
        switch (pack.Returncode)
        {
            case ReturnCode.Succeed:
                UIManager.GetInstance().Pop(true);
                SelectPanel selectPanel = new SelectPanel();
                selectPanel.loadGameModel = false;
                UIManager.GetInstance().Push(selectPanel);
                UIManager.GetInstance().Push(new RoomlistCooperatePanel());
                foreach (var pla in GameObject.FindGameObjectsWithTag("Player"))
                {
                    Destroy(pla);
                }
                
                Instantiate(player, new Vector3(0, 1.09f, 0), Quaternion.identity).gameObject.GetComponentInChildren<TMP_Text>();
                break;
            case ReturnCode.Fail:
                Debug.Log("失败");
                break;
            default:
                break;
        }
    }

    public void OtherPlayerChange(MainPack pack)
    {
        foreach (var pla in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(pla);
        }
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
    }

    public void ChatResponse(string str)
    {

        Instantiate(chatOne, content.transform).gameObject.GetComponent<Text>().text = str;
        //GameObject text = Instantiate(chatOne, chatOne.transform.position, Quaternion.identity);
        //text.transform.SetParent(content.transform);
        //text.gameObject.GetComponent<Text>().text = str;
    }

    public void StartGameResponse(MainPack pack)
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
    }
}
