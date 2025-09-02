using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�̏����擾����

public class GetPlayerInfo : MonoBehaviour
{
    [Tooltip("�v���C���[�̃I�u�W�F�N�g�̃^�O��")] [SerializeField] string _playerObjectTagName;

    PlayerInfo[] _playerInfos;//�������S�Ẵv���C���[�̏��
    PlayerInfo _myPlayerInfo;//�����̃v���C���[���

    //PlayerInfo�ŕԂ�
    public PlayerInfo MyPlayerInfo { get { return _myPlayerInfo; } }
        
    public PlayerInfo[] PlayerInfos { get { return _playerInfos; } }

    //GameObject�ŕԂ�
    public GameObject MyPlayerObject { get { return _myPlayerInfo.PlayerObject; } }

    public GameObject[] PlayerObjects 
    {
        get
        {
            GameObject[] ret = new GameObject[_playerInfos.Length];

            for(int i=0; i<ret.Length ;i++)
            {
                ret[i]= _playerInfos[i].PlayerObject;
            }

            return ret; 
        } 
    }


    //private
    private void Awake()
    {
        //�V�[�����̑S�Ẵv���C���[�^�O�������I�u�W�F�N�g���擾
        GameObject[] playerObjects = GameObject.FindGameObjectsWithTag(_playerObjectTagName);

        //�v���C���[�̐l�����z������
        _playerInfos = new PlayerInfo[playerObjects.Length];

        for(int i=0; i< playerObjects.Length ;i++)
        {
            //���̃v���C���[�I�u�W�F�N�g�̃I�[�i�[(�v���C���[)���擾
            PhotonView photonView = playerObjects[i].GetPhotonView();
            Player player = photonView.Owner;

            _playerInfos[i] = new PlayerInfo(playerObjects[i],player);

            //�����̂Ȃ玩���̃v���C���[���ɓo�^
            if(photonView.IsMine)
            {
                _myPlayerInfo = _playerInfos[i];
            }
        }

        //�z��ɑS�Ċi�[������AactorNumber�̏��������ɕ��ׂ�
        System.Array.Sort(_playerInfos, (a, b) => a.ActorNum.CompareTo(b.ActorNum));
    }
}
