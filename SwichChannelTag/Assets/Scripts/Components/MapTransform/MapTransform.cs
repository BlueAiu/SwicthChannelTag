using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�L�����̃}�b�v��̈ʒu���(�}�b�v��̈ʒu�ƃ��[���h��̈ʒu�𓯊�������)

public partial class MapTransform : MonoBehaviour
{
    [Tooltip("�ړ��ł���K�w�ꗗ")][SerializeField] Maps_Hierarchies _hierarchies;
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


    public void MoveSmoothly(MapVec newMapPos,float duration)//���炩�ɐV�����}�X�ֈړ�
    {
        //duration��_minDuration�ȉ��̏ꍇ�͑����ړ��Ƃ��ď���
        if (duration <= _minDuration)
        {
            Pos = newMapPos;
            return;
        }

        StartMoveSmoothly(newMapPos,duration);
    }
    public bool Moving { get { return _moving; } }//�ړ�����


    public int HierarchyIndex //���݂̊K�w�ԍ�
    {
        get { return _hierarchyIndex; }
        set { RewritePos(_pos, value); }
    }
    public Map_A_Hierarchy CurrentHierarchy { get { return _hierarchies[_hierarchyIndex]; } }//���݂̊K�w
    public Maps_Hierarchies Hierarchies { get { return _hierarchies; } }//�ړ�����K�w�ꗗ
    



    //private

    void RewritePos(MapVec newMapPos, int newHierarchyIndex)//�ʒu�ƊK�w�̏�������
    {
        if(_target==null|| _hierarchies == null)
        {
            Debug.Log("�C���X�y�N�^�[�Őݒ肳��Ă��Ȃ��ӏ�������悤�ł��I");
            return;
        }

        //�ʒu���͈͊O��������x�����Ēe��
        if (!CurrentHierarchy.IsInRange(newMapPos))
        {
            Debug.Log(newMapPos + "�͔͈͊O�̈ʒu�ł��I");
            return;
        }

        //�K�w�ԍ����͈͊O��������x�����͈͓��Ɏ��߂�
        if (_hierarchyIndex < 0 || _hierarchyIndex >= _hierarchies.Length)
        {
            Debug.Log(_hierarchyIndex + "�͔͈͊O�̊K�w�ԍ��ł��I");
            return;
        }

        _hierarchyIndex = newHierarchyIndex;
        _pos = newMapPos;
        Vector3 newWorldPos = CurrentWorldPos;
        _target.position = newWorldPos;
    }


    void Start()
    {
        RewritePos(_pos, _hierarchyIndex);
    }

    private void Update()
    {
        UpdateMoveSmoothly();
    }

    private void OnValidate()
    {
        RewritePos(_pos, _hierarchyIndex);
    }
}
