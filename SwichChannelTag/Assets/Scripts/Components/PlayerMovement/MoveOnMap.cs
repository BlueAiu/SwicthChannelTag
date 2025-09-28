using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�v���C���[�̃}�b�v��̈ړ�����
//enabled��false�ɂ���΁A�{�^���������Ă��ړ����o���Ȃ����邱�Ƃ��o����

public class MoveOnMap : MonoBehaviour
{
    [Tooltip("��̃}�X�̈ړ��ɂ����鎞��")] [SerializeField]
    float _moveDuration;

    [Tooltip("�}�b�v��̈ʒu���")] [SerializeField]
    MapTransform _mapTrs;

    int _remainingStep=0;//�c��ړ��\�}�X��

    public int RemainingStep
    {
        get { return _remainingStep; }
        set { _remainingStep = value; }
    }

    public void MoveControl(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (!enabled) return;

        //if (_mapTrs.Moving) return;//�L�������ړ����ł���Ζ���

        if (_remainingStep <= 0) return;//�c��ړ��\�}�X��0�Ȃ�ړ��ł��Ȃ�

        Vector2 getVec = context.ReadValue<Vector2>();

        if (!Move(getVec)) return;

        _remainingStep--;//�ړ��o�����Ȃ�A�c��ړ��\�}�X�����炵�Ă���
    }



    //private
    bool Move(Vector2 inputVec)//�w������Ɉړ�(�ړ��Ɏ��s������false��Ԃ�)
    {
        MapVec moveVec;
        moveVec.x = (int)inputVec.x;
        moveVec.y = -(int)inputVec.y;

        MapVec newPos = _mapTrs.Pos.gridPos + moveVec;

        if (!IsMovableMass(newPos))//�ړ��ł��Ȃ��ꍇ
        {
            Debug.Log("�ړ��Ɏ��s");
            return false;
        }

        //�ړ��\�ȏꍇ
        //_mapTrs.MoveSmoothly(newPos,_moveDuration);
        return true;
    }

    bool IsMovableMass(MapVec newPos)//�ړ��\�ȃ}�X��
    {
        if (!_mapTrs.CurrentHierarchy.IsInRange(newPos)) return false;//�͈͊O�̃}�X�ł���Έړ��ł��Ȃ�
        if (_mapTrs.CurrentHierarchy.Mass[newPos] != E_Mass.Empty) return false;//���̃}�X����}�X�łȂ���Έړ��ł��Ȃ�

        return true;
    }

    private void Start()
    {
        Init();
    }

    private void Init()//����������
    {
        _mapTrs = PlayersManager.GetComponentFromMinePlayer<MapTransform>();
    }
}
