using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�L�����̃}�b�v��̈ʒu���

public partial class MapTransform : MonoBehaviour
{
    [Tooltip("�ړ�����K�w�ꗗ")][SerializeField] Map_A_Hierarchy[] _hierarchies;
    [Tooltip("�������Ώ�")][SerializeField] Transform _target;
    [Tooltip("�ʒu")][SerializeField] MapVec _pos;
    [Tooltip("�K�w�ԍ�")][SerializeField] int _hierarchyIndex;


    public Transform Target { get { return _target; } }//�������Ώ�

    public MapVec Pos//���݂̃}�b�v��̈ʒu
    {
        get { return _pos; }
        set { RewritePos(value, _hierarchyIndex); }
    }
    public Vector3 CurrentWorldPos { get { return CurrentHierarchy.MapToWorld(_pos); } }//���݂̃��[���h��̈ʒu

    public int HierarchyIndex //���݂̊K�w�ԍ�
    {
        get { return _hierarchyIndex; }
        set { RewritePos(_pos, value); }
    }
    public Map_A_Hierarchy CurrentHierarchy { get { return _hierarchies[_hierarchyIndex]; } }//���݂̊K�w
    public Map_A_Hierarchy[] Hierarchies { get { return _hierarchies; } }//�ړ�����K�w�ꗗ





    //private

    void RewritePos(MapVec newMapVec, int newHierarchyIndex)//�ʒu�ƊK�w�̏�������
    {
        if(_target==null)
        {
            Debug.Log("Target���ݒ肳��Ă��܂���I");
            return;
        }

        //�ʒu���͈͊O��������x�����Ēe��
        if (!CurrentHierarchy.IsInRange(newMapVec))
        {
            Debug.Log(newMapVec + "�͔͈͊O�̈ʒu�ł��I");
            return;
        }

        //�K�w�ԍ����͈͊O��������x�����͈͓��Ɏ��߂�
        if (_hierarchyIndex < 0 || _hierarchyIndex >= _hierarchies.Length)
        {
            Debug.Log(_hierarchyIndex + "�͔͈͊O�̊K�w�ԍ��ł��I");
            return;
        }

        _hierarchyIndex = newHierarchyIndex;
        _pos = newMapVec;
        Vector3 newPos = CurrentWorldPos;
        _target.position = newPos;
    }

    void Start()
    {
        RewritePos(_pos, _hierarchyIndex);
    }

    private void OnValidate()
    {
        RewritePos(_pos, _hierarchyIndex);
    }
}
