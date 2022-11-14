using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;

public class StartGameRequest : BaseRequest
{
    private MainPack pack = null;

    public override void Awake()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.StartGame;
        base.Awake();
    }

    private void Update()
    {
        if (pack != null)
        {
            face.StartGameResponse(pack);
            pack = null;
        }
    }

    public void SendRequest()
    {
        MainPack pack = new MainPack();
        pack.Requestcode = requestCode;
        pack.Actioncode = actionCode;
        pack.Str = "";
        base.SendRequest(pack);
    }

    public override void OnResponse(MainPack pack)
    {
        this.pack = pack;
    }
}
