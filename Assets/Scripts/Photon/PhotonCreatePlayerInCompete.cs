using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class PhotonCreatePlayerInCompete : MonoBehaviourPun
{
    CinemachineTargetGroup cinemachineTargetGroup;

    CinemachineTargetGroup.Target target;
    private void Awake()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Compete compete = new Compete();
            SceneControl.GetInstance().AddScene(compete.SceneName, compete);
        }

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (var pla in players)
        {
            if (pla.GetComponent<PhotonView>().IsMine)
            {
                return;
            }
            else
            {
                continue;
            }
        }
        cinemachineTargetGroup = GameObject.FindWithTag("CinemachineTargetGroup").gameObject.GetComponent<CinemachineTargetGroup>();
        GameObject player = PhotonNetwork.Instantiate("Player", new Vector3(0, 1.09f, 0), Quaternion.identity, 0);

        cinemachineTargetGroup.AddMember(player.transform, 1, 1);
    }
}
