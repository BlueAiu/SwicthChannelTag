using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviourPunCallbacks
{
    List<GameObject> players = new();

    public GameObject[] Players { get => players.ToArray(); }
   
    void ResetPlayersList()
    {
        players.Clear();

        foreach(var i in GameObject.FindGameObjectsWithTag("Player"))
        {
            players.Add(i);
        }
    }

    //�v���C���[�B��Component��z��Ŏ擾
    public T[] GetComponentsFromPlayers<T>() where T : Component
    {
        List<T> ret = new();

        foreach (var i in players)
        {
            if(i == null) continue;
            T comp = i.GetComponent<T>();
            if (comp != null)
            {
                ret.Add(comp);
            }
        }

        return ret.ToArray();
    }

    // �������A���v���C���[�����������A���v���C���[�����������A���X�g���X�V����

    public override void OnJoinedRoom()
    {
        ResetPlayersList();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        ResetPlayersList();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        ResetPlayersList();
    }
}
