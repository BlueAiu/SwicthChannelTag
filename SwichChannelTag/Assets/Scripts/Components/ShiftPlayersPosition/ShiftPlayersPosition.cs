using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�B�̈ʒu�����炷

public class ShiftPlayersPosition : MonoBehaviour
{
    [Tooltip("�}�X�̒��S�_����ǂ̈ʒu�܂ł��炷��")] [SerializeField]
    Vector3[] offsets;

    [Tooltip("�d�Ȃ��Ă���v���C���[���擾����@�\")] [SerializeField]
    GetOverlapPlayer _getOverlapPlayer;

    SetTransform[] _setTransform;


    public void OnExit()//�}�X����o�Ă�����(�����̃}�X������������O�ɓǂ�ł�������)
    {
        //�d�Ȃ��Ă���v���C���[���擾

        //�����ȊO�̓����}�X�̃v���C���[�̈ʒu�����炷
    }

    public void OnEnter()//�}�X�ɓ���������(�����̃}�X�����������Ă���ǂ�ł�������)
    {
        //�d�Ȃ��Ă���v���C���[���擾

        //�����̈ʒu�����炷
    }


    //private
    private void Awake()
    {
        _setTransform = PlayersManager.GetComponentsFromPlayers<SetTransform>();
    }
}
