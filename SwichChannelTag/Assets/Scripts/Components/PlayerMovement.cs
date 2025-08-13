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
    [Tooltip("�K�w�̈ړ��֌W")] [SerializeField] ChangeHierarchy _changeHierarchy;
    [Tooltip("�����ʒu")] [SerializeField] MapVec _startPoint;
    [Tooltip("�����K�w�ԍ�")] [SerializeField] int _initHierarchyIndex;

    private MapVec _currentPos;//���݂̈ʒu���
    private int _currentHierarchyIndex;//���݂̊K�w�ԍ�

    public MapVec CurrentPos { get { return _currentPos; } }//���݂̈ʒu

    public int CurrentHierarchyIndex { get { return _currentHierarchyIndex; } }

    void Start()
    {
        //�����ʒu�̐ݒ�
        Map_A_Hierarchy firstMap = _changeHierarchy.Change_Index(ref _currentHierarchyIndex, _initHierarchyIndex);
        _moveOnMap.RewritePos(out _currentPos,_startPoint, firstMap);
        
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 getVec = context.ReadValue<Vector2>();

        Debug.Log(getVec);

        if(!_moveOnMap.Move(ref _currentPos,getVec)) Debug.Log("�ړ��ł��܂���ł���");
    }

    public void SwitchHierarchy_Inc(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Map_A_Hierarchy newMap = _changeHierarchy.Change_Delta(ref _currentHierarchyIndex,1);
        _moveOnMap.RewritePos(out _currentPos, _currentPos, newMap);
    }

    public void SwitchHierarchy_Dec(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Map_A_Hierarchy newMap = _changeHierarchy.Change_Delta(ref _currentHierarchyIndex,-1);
        _moveOnMap.RewritePos(out _currentPos, _currentPos, newMap);
    }
}
