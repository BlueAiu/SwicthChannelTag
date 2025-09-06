using Photon.Pun;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayersManager : MonoBehaviourPunCallbacks
{
    static List<GameObject> players = new();

    public GameObject[] Players 
    { 
        get 
        {
            return players.ToArray();
        }
    }

    public static void AddPlayer(GameObject player)
    {
        if (players.Contains(player)) return;
        players.Add(player);
        SortByActorNumber();
    }

    public static void RemovePlayer(GameObject player)
    {
        if (!players.Contains(player)) return;
        players.Remove(player);
        SortByActorNumber();
    }

    static void SortByActorNumber()
    {
        players.Sort((a, b) => 
        a.GetPhotonView().Owner.ActorNumber.CompareTo(
            b.GetPhotonView().Owner.ActorNumber));
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
}
