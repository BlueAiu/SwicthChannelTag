using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�L�����̓����R���|�[�l���g(�e�X�g�p)

public class MoveOnMap : MonoBehaviour
{
    [SerializeField] Map_A_Hierarchy _map;
    [SerializeField] MapVec _startPoint;

    private MapVec _currentPos;

    void Start()
    {
        //�ʒu�̏�����
        RewritePos(_startPoint);
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 getVec = context.ReadValue<Vector2>();

        Debug.Log(getVec);

        MapVec moveVec;
        moveVec.x = (int)getVec.x;
        moveVec.y = (int)getVec.y;

        RewritePos(_currentPos+moveVec);
    }

    void RewritePos(MapVec newMapVec)//�ʒu�̏�������
    {
        _currentPos = _map.ClampInRange(newMapVec);//�͈͊O�̈ʒu�ɍs���Ȃ��悤�ɂ��邽�߂̏��u
        Vector3 newPos;

        _map.Transit_FromMapVec_ToWorldVec(_currentPos, out newPos);
        transform.position = newPos;
    }
}
