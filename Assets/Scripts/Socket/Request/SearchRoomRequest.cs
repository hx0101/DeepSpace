using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol; 

public class SearchRoomRequest : BaseRequest
{
    private MainPack pack = null;

    public override void Awake()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.SearchRoom;
        base.Awake();
    }

    private void Update()
    {
        if (pack != null)
        {
            face.SearchRoom(pack);
            pack = null;
        }
    }

    public void SendRequest()
    {
        MainPack pack = new MainPack();
        pack.Requestcode = requestCode;
        pack.Actioncode = actionCode;
        pack.Str = "Hx";
        base.SendRequest(pack);
    }

    public override void OnResponse(MainPack pack)
    {
        this.pack = pack;
    }
}
