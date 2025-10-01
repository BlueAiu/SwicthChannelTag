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


    public void OnExit(MapTransform myMapTrs)//�}�X����o�Ă�����(�����̃}�X������������O�ɌĂ�)
    {
        PlayerInfo[] overlapPlayersInfos= _getOverlapPlayer.GetOverlapPlayers();//�d�Ȃ��Ă���v���C���[���擾(����ɔԍ����擾����悤�ɂ���)
        Vector3 massCenterPos = myMapTrs.CurrentWorldPos;//�}�X�̒��S�_���擾
        int offsetIndex=0;

        //�����ȊO�̓����}�X�̃v���C���[�̈ʒu�����炷
        for (int i=0; i<overlapPlayersInfos.Length ;i++)
        {
            SetTransform setTransform=overlapPlayersInfos[i].GetComponent<SetTransform>();
            CanShift canShift = overlapPlayersInfos[i].GetComponent<CanShift>();

            if (overlapPlayersInfos[i].Player.IsLocal) continue;//�����������炸�炳�Ȃ�

            else if (canShift.IsShiftAllowed)//����ȊO�̐l�Ȃ炸�炵�Ă������Ȃ炸�炷
            {
                Vector3 pos = massCenterPos + _offsets[offsetIndex];//�ړ��ʒu
                setTransform.Position = pos;

                offsetIndex++;
            }
        }
    }

    public void OnEnter(MapTransform myMapTrs)//�}�X�ɓ���������(�����̃}�X�����������Ă���Ă�)
    {
        PlayerInfo[] overlapPlayersInfos = _getOverlapPlayer.GetOverlapPlayers();//�d�Ȃ��Ă���v���C���[���擾(����ɔԍ����擾����悤�ɂ���)
        Vector3 massCenterPos = myMapTrs.CurrentWorldPos;//�}�X�̒��S�_���擾
        int offsetIndex = overlapPlayersInfos.Length;
        Debug.Log(offsetIndex);
        SetTransform mySetTrs = PlayersManager.GetComponentFromMinePlayer<SetTransform>();

        //�����̈ʒu�����炷
        Vector3 pos = massCenterPos + _offsets[offsetIndex];//�ړ��ʒu
        mySetTrs.Position = pos;
    }
}
