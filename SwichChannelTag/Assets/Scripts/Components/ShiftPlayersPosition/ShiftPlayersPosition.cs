using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�B�̈ʒu�����炷

public class ShiftPlayersPosition : MonoBehaviour
{
    [Tooltip("�}�X�̒��S�_����ǂ̈ʒu�܂ł��炷��")] [SerializeField]
    Vector3[] _offsets;

    [Tooltip("�d�Ȃ��Ă���v���C���[���擾����@�\")] [SerializeField]
    GetOverlapPlayer _getOverlapPlayer;

    SetTransform[] _setTransforms;
    CanShift[] _canShifts;


    public void OnExit(MapTransform myMapTrs)//�}�X����o�Ă�����(�����̃}�X������������O�ɌĂ�)
    {
        int[] overlapPlayersIndexs= { };//�d�Ȃ��Ă���v���C���[���擾(����ɔԍ����擾����悤�ɂ���)
        Vector3 massCenterPos = myMapTrs.CurrentWorldPos;//�}�X�̒��S�_���擾
        int offsetIndex=0;

        //�����ȊO�̓����}�X�̃v���C���[�̈ʒu�����炷
        for (int i=0; i<overlapPlayersIndexs.Length ;i++)
        {
            int overlapIndex=overlapPlayersIndexs[i];

            if (overlapIndex == PlayersManager.MyIndex) continue;//�����������炸�炳�Ȃ�

            else if (_canShifts[i].IsShiftAllowed)//����ȊO�̐l�Ȃ炸�炵�Ă������Ȃ炸�炷
            {
                Vector3 pos = massCenterPos + _offsets[offsetIndex];//�ړ��ʒu
                _setTransforms[i].Position = pos;

                offsetIndex++;
            }
        }
    }

    public void OnEnter(MapTransform myMapTrs)//�}�X�ɓ���������(�����̃}�X�����������Ă���Ă�)
    {
        int[] overlapPlayersIndex = { };//�d�Ȃ��Ă���v���C���[���擾(����ɔԍ����擾����悤�ɂ���)
        Vector3 massCenterPos = myMapTrs.CurrentWorldPos;//�}�X�̒��S�_���擾
        int offsetIndex = overlapPlayersIndex.Length-1;

        //�����̈ʒu�����炷
        Vector3 pos = massCenterPos + _offsets[offsetIndex];//�ړ��ʒu
        _setTransforms[PlayersManager.MyIndex].Position = pos;
    }


    //private
    private void Awake()
    {
        _canShifts = PlayersManager.GetComponentsFromPlayers<CanShift>();
        _setTransforms = PlayersManager.GetComponentsFromPlayers<SetTransform>();
    }
}
