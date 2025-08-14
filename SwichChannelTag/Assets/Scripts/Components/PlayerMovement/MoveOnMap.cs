using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�v���C���[�̃}�b�v��̈ړ�����

public class MoveOnMap : MonoBehaviour
{
    [SerializeField] MapTransform _mapTrs;

    public void MoveControl(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 getVec = context.ReadValue<Vector2>();

        if (!Move(getVec)) Debug.Log("�ړ��ł��܂���ł���");
    }

    bool Move(Vector2 inputVec)//�w������Ɉړ�(�ړ��Ɏ��s������false��Ԃ�)
    {
        MapVec moveVec;
        moveVec.x = (int)inputVec.x;
        moveVec.y = -(int)inputVec.y;

        MapVec newPos = _mapTrs.Pos + moveVec;

        if (!_mapTrs.CurrentHierarchy.IsInRange(newPos) || _mapTrs.CurrentHierarchy.Mass[newPos] != E_Mass.Empty) return false;//�ړ��ł��Ȃ��ꍇ

        _mapTrs.Pos=newPos;
        return true;
    }
}
