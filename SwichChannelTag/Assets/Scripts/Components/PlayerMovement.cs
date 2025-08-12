using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�L�����̓����R���|�[�l���g(�v���g�^�C�v�i�K)

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("�}�b�v��̈ړ��֌W")] [SerializeField] MoveOnMap _moveOnMap;
    [Tooltip("�����ʒu")][SerializeField] MapVec _startPoint;
    private MapVec _currentPos;//���݂̈ʒu���

    public MapVec CurrentPos { get { return _currentPos; } }//���݂̈ʒu

    void Start()
    {
        _moveOnMap.RewritePos(out _currentPos,_startPoint);//���݈ʒu�̏�����
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 getVec = context.ReadValue<Vector2>();

        Debug.Log(getVec);

        if(!_moveOnMap.Move(ref _currentPos,getVec)) Debug.Log("�ړ��ł��܂���ł���");
    }
}
