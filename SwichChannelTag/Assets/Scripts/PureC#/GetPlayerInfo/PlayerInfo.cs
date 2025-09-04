using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//�쐬��:���R
//�v���C���[�̏��

public class PlayerInfo
{
    GetPlayerInfo _getPlayerInfo;//�v���C���[�̃R���|�[�l���g���擾����@�\
    GameObject _playerObject;//�v���C���[�I�u�W�F�N�g
    Player _player;//�v���C���[�̏��

    public PlayerInfo(GameObject playerObject,Player player, GetPlayerInfo getPlayerInfo)
    {
        _playerObject = playerObject;
        _player = player;
        _getPlayerInfo = getPlayerInfo;
    }

    public GameObject PlayerObject { get { return _playerObject; } }//�v���C���[�I�u�W�F�N�g
    public Player Player { get { return _player; } }//�v���C���[�̏��
    public T GetComponent<T>() where T:Component { return _getPlayerInfo.GetComponent<T>(); }//�v���C���[�̃R���|�[�l���g�̎擾
}
