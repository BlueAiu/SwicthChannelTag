using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

public class GettingReady : MonoBehaviourPunCallbacks
{
    bool isReady = false;
    public bool IsReady 
    { 
        get => isReady;
        private set { photonView.RPC(nameof(SetIsReady), RpcTarget.All, value); }
    }


    public void SwitchReady()
    {
        IsReady = !IsReady;
    }

    //�V���ɎQ���҂����������A�l���ē���������
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        photonView.RPC(nameof(SetIsReady), RpcTarget.All, IsReady);
    }

    [PunRPC]
    void SetIsReady(bool value)
    {
        isReady = value;
    }
}
