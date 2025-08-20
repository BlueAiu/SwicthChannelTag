using UnityEngine;
using System.Collections;
using Photon.Pun;
using Photon.Realtime;

public class JoinGame : MonoBehaviourPunCallbacks
{
    [SerializeField] bool writeJoinLog = true;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        WriteLog("Start Join Room...");
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
        WriteLog("Joined Room.");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        WriteLog("JoinFailed : " + message);
    }

    void WriteLog(string message)
    {
        if (writeJoinLog) Debug.Log(message);
    }
}

