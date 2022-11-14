using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;

public class JoinRequest : BaseRequest
{
    private MainPack pack = null;
    public override void Awake()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.JoinRoom;
        base.Awake();
    }

    private void Update()
    {
        if (pack != null)
        {
            face.JoinRoom(pack);
            pack = null;
        }
    }

    public void SendRequest(string roomname)
    {
        MainPack pack = new MainPack();
        pack.Requestcode = requestCode;
        pack.Actioncode = actionCode;
        pack.Str = roomname;
        base.SendRequest(pack);
    }

    public override void OnResponse(MainPack pack)
    {
        this.pack = pack;
    }
}
