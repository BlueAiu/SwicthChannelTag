using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�L�����̃}�b�v��̈ʒu���

public partial class MapTransform : MonoBehaviour
{
    [Tooltip("�ړ�����K�w�ꗗ")][SerializeField] Map_A_Hierarchy[] _hierarchies;
    [Tooltip("�������Ώ�")][SerializeField] Transform _target;
    [Tooltip("�����ʒu")][SerializeField] MapVec _startPoint;
    [Tooltip("�����K�w�ԍ�")][SerializeField] int _initHierarchyIndex;

    private MapVec _currentPos;//���݂̈ʒu���
    private int _currentHierarchyIndex;//���݂̊K�w�ԍ�


    public Transform Target { get { return _target; } }//�������Ώ�

    public MapVec CurrentPos { get { return _currentPos; } }//���݂̃}�b�v��̈ʒu
    public Vector3 CurrentWorldPos { get { return CurrentHierarchy.MapToWorld(_currentPos); } }//���݂̃��[���h��̈ʒu

    public int CurrentHierarchyIndex { get { return _currentHierarchyIndex; } }//���݂̊K�w�ԍ�
    public Map_A_Hierarchy CurrentHierarchy { get { return _hierarchies[CurrentHierarchyIndex]; } }//���݂̊K�w
    public Map_A_Hierarchy[] Hierarchies { get { return _hierarchies; } }//�ړ�����K�w�ꗗ

    public void RewritePos(MapVec newMapVec, int newHierarchyIndex)//�ʒu�ƊK�w�̏�������
    {
        _currentHierarchyIndex = newHierarchyIndex;
        RewritePos(newMapVec);
    }

    public void RewritePos(int newHierarchyIndex)//�K�w�݂̂̏�������
    {
        RewritePos(_currentPos,newHierarchyIndex);
    }

    public void RewritePos(MapVec newMapVec)//�ʒu�݂̂̏�������
    {
        _currentPos = newMapVec;
        Vector3 newPos = CurrentHierarchy.MapToWorld(_currentPos);
        _target.position = newPos;
    }


    //private

    void Start()
    {
        //�����ʒu�̐ݒ�
        RewritePos(_startPoint, _initHierarchyIndex);
    }
}
