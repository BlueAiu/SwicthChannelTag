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

    void Start()
    {
        _moveOnMap.Start();
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 getVec = context.ReadValue<Vector2>();

        Debug.Log(getVec);

        if(!_moveOnMap.Move(getVec)) Debug.Log("�ړ��ł��܂���ł���");
    }
}
