using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

//�쐬��:���R
//�v���C���[�̏��

public class PlayerInfo
{
    GameObject _playerObject;//�v���C���[�I�u�W�F�N�g
    Player _player;//�v���C���[�̏��
    const int _errorNum = -1;

    public PlayerInfo(GameObject playerObject,Player player)
    {
        _playerObject = playerObject;
        _player = player;
    }

    public GameObject PlayerObject//�v���C���[�I�u�W�F�N�g
    {
        get { return _playerObject; }
        set { _playerObject = value; }
    }

    public Player Player//�v���C���[�̏��
    {
        get { return _player; }
        set { _player = value; }
    }

    public int ActorNum//�v���C���[�̃A�N�^�\�i���o�[(�����������ɕ��񂾃v���C���[���Ƃ�ID�݂����Ȃ���)�A�擾�Ɏ��s������_errorNum(-1)��Ԃ�
    {
        get
        {
            if (_player == null) return _errorNum;
            return _player.ActorNumber;
        }
    }

    public string ID//�v���C���[ID(������^�̃v���C���[���Ƃ�ID)�A�擾�Ɏ��s������null��Ԃ�
    {
        get
        {
            if (_player == null) return null;
            return _player.UserId;
        }
    }
}
