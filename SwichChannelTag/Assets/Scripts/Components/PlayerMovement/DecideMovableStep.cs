using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R
//������}�X�������߂�

public class DecideMovableStep : MonoBehaviour
{
    [Tooltip("�_�C�X�̍ő�l(1�`MaxNum�ȉ��̒l���o��)")] [SerializeField] int _maxNum;
    [SerializeField] MoveOnMap _moveOnMap;
    [SerializeField] TextMeshProUGUI _diceResultText;
    const int _minNum=1;

    [SerializeField] ChangeHierarchy _changeHierarchy;

    public void Dicide()//������}�X��������(�_�C�X���[����)
    {
        int result=Random.Range(_minNum, _maxNum+1);
        _moveOnMap.RemainingStep=result;

        if(_changeHierarchy.IsMoved)
        {
            _changeHierarchy.IsMoved = false;
        }
    }

    private void Update()
    {
        _diceResultText.text = _moveOnMap.RemainingStep.ToString();//�e�L�X�g�Ɏc��ړ��\�}�X����\��
    }
}
