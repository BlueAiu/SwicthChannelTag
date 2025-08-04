using UnityEngine;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;

public class Pun_JoinGame : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Start Join Room...");
    }

    void OnGUI()
    {
        // ���O�C���̏�Ԃ�GUI�ɏo��
        //GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }


    // ���[���ɓ����O
    public override void OnConnectedToMaster()
    {
        // "room"�Ƃ������O�̃��[���ɎQ������i���[����������΍쐬���Ă���Q������j
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    // ���[���ɓ�����
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room.");
    }
}

