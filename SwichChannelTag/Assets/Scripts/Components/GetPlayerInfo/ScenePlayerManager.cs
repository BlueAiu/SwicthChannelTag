using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���̃V�[�����̑S�v���C���[�̏����擾���邱�Ƃ��ł���

//*�g�p��̒���*
//Awake�i�K�ł̓V�[�����̑S�v���C���[�̔c���������s���Ă���̂ŁA
//�v���C���[�̏��擾��Start�ł��悤�ɂ��Ă�������

public class ScenePlayerManager : MonoBehaviour
{
    [Tooltip("�v���C���[�̃I�u�W�F�N�g�̃^�O��")] [SerializeField] string _playerObjectTagName;
    PlayerInfo[] _playerInfos;//�S�v���C���[�̏��
    int _myPlayerIndex;//�����̃v���C���[�̗v�f�ԍ�

    
    public int MyPlayerIndex { get { return _myPlayerIndex; } }//�����̃v���C���[�ԍ�


    //�����̃v���C���[�̏��擾�֌W
    public Player MyPlayer { get { return MyPlayerInfo.Player; } }//Player�̎擾

    public GameObject MyPlayerObject { get { return MyPlayerInfo.PlayerObject; } }//�I�u�W�F�N�g�̎擾

    public T MyComponent<T>() where T : Component { return MyPlayerInfo.GetComponent<T>(); }//�R���|�[�l���g�̎擾



    //�S�v���C���[�̏��擾�֌W
    public Player[] Players //Player�̎擾
    {
        get
        {
            Player[] ret = new Player[_playerInfos.Length];

            for(int i=0; i< _playerInfos.Length; i++)
            {
                ret[i]=_playerInfos[i].Player;
            }

            return ret;
        
        }
    }

    public GameObject[] PlayerObjects//�I�u�W�F�N�g�̎擾
    {
        get
        {
            GameObject[] ret = new GameObject[_playerInfos.Length];

            for(int i=0; i<_playerInfos.Length ;i++)
            {
                ret[i] = _playerInfos[i].PlayerObject;
            }

            return ret;
        }
    }

    public T[] PlayerComponents<T>() where T:Component//�R���|�[�l���g�̎擾
    {
        T[] ret = new T[_playerInfos.Length];

        for(int i = 0; i < _playerInfos.Length; i++)
        {
            ret[i] = _playerInfos[i].GetComponent<T>();
        }

        return ret;
    }



    //private
    PlayerInfo MyPlayerInfo { get { return _playerInfos[_myPlayerIndex]; } }

    private void Awake()
    {
        InitPlayerInfos();
    }

    void InitPlayerInfos()
    {
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag(_playerObjectTagName);

        _playerInfos = new PlayerInfo[playerObjects.Length];

        //�S�v���C���[�̏����擾���Ċi�[
        for (int i = 0; i < playerObjects.Length; i++)
        {
            GameObject playerObject = playerObjects[i];

            //���̃v���C���[�I�u�W�F�N�g�̃I�[�i�[(�v���C���[)���擾
            PhotonView photonView = playerObject.GetPhotonView();
            if (photonView == null) Debug.Log(playerObject.name+"��PhotonView�����Ă܂���I");
            Player player = photonView.Owner;

            //���̃v���C���[�̏����擾����@�\���擾
            GetPlayerInfo getPlayerInfo= playerObject.GetComponent<GetPlayerInfo>();
            if (getPlayerInfo == null) Debug.Log(playerObject.name + "��GetPlayerInfo�����Ă܂���I");

            _playerInfos[i] = new PlayerInfo(playerObject, player,getPlayerInfo);
        }


        //�z��ɑS�Ċi�[������AactorNumber�̏��������ɕ��ׂ�
        System.Array.Sort(_playerInfos, (a, b) => a.Player.ActorNumber.CompareTo(b.Player.ActorNumber));


        //�����̃v���C���[�̗v�f�ԍ���T��
        for (int i = 0; i < playerObjects.Length; i++)
        {
            if (_playerInfos[i].Player == PhotonNetwork.LocalPlayer)
            {
                _myPlayerIndex = i;
                return;
            }
        }
    }
}
