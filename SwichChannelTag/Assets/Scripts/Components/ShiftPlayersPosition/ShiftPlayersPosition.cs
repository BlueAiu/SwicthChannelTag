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


    public void OnExit(MapTransform myMapTrs)//�}�X����o�Ă�����(�����̃}�X������������O�ɌĂ�)
    {
        int[] overlapPlayersIndexs= { };//�d�Ȃ��Ă���v���C���[���擾
        Vector3 massCenterPos = myMapTrs.CurrentWorldPos;//�}�X�̒��S�_���擾

        int offsetIndex=0;

        for(int i=0; i<overlapPlayersIndexs.Length ;i++)//�����ȊO�̓����}�X�̃v���C���[�̈ʒu�����炷
        {
            int overlapIndex=overlapPlayersIndexs[i];

            if (overlapIndex == PlayersManager.MyIndex) continue;//�����������炸�炳�Ȃ�

            if(true)//����ȊO�̐l�Ȃ炸�炵�Ă������Ȃ炸�炷
            {
                //�}�X�̒��S�_��offset�𑫂�

                //�v���C���[�̈ʒu�𓮂���

                offsetIndex++;
            }
        }
    }

    public void OnEnter()//�}�X�ɓ���������(�����̃}�X�����������Ă���Ă�)
    {
        int[] overlapPlayersIndex = { };//�d�Ȃ��Ă���v���C���[���擾

        //�����̈ʒu�����炷
    }


    //private
    private void Awake()
    {
        _setTransforms = PlayersManager.GetComponentsFromPlayers<SetTransform>();
    }
}
