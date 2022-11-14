using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketGameProtocol;

public class PlayerRequest : BaseRequest
{
    private MainPack pack = null;
    public override void Awake()
    {
        actionCode = ActionCode.PlayerList;
        base.Awake();
    }

    private void Update()
    {
        if (pack != null)
        {
            face.OtherPlayerChange(pack);
            pack = null;
        }
    }

    public override void OnResponse(MainPack pack)
    {
        this.pack = pack;
    }
}
