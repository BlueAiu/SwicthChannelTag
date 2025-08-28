using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

//�쐬��:���R
//�L�����̃}�b�v��̈ʒu���(�}�b�v��̈ʒu�ƃ��[���h��̈ʒu�𓯊�������)

public partial class MapTransform : MonoBehaviour
{
    [Tooltip("�ړ��ł���K�w�ꗗ")][SerializeField] Maps_Hierarchies _hierarchies;
    [Tooltip("�������Ώ�")][SerializeField] Transform _target;
    [Tooltip("�ʒu")][SerializeField] MapVec _pos;
    [Tooltip("�K�w�ԍ�")][SerializeField] int _hierarchyIndex;
    [SerializeField] PhotonView _myPhotonView;


    public Transform Target { get { return _target; } }//�������Ώ�


    public MapVec Pos { get { return _pos; } }//���݂̃}�b�v��̈ʒu
    public Vector3 CurrentWorldPos { get { return CurrentHierarchy.MapToWorld(_pos); } }//���݂̃��[���h��̈ʒu


    public void MoveSmoothly(MapVec newMapPos,float duration,bool isSync)//���炩�ɐV�����}�X�ֈړ�
    {
        //��������������PhotonView���ݒ肳��Ă��Ȃ��ꍇ�́A�x�����ē������Ȃ��ړ��Ƃ��ď�������
        if (isSync && _myPhotonView == null)
        {
            Debug.Log("PhotonView���ݒ肳��Ă��Ȃ��̂ŁA�񓯊��ړ��Ƃ��ď������܂��I");
            isSync = false;
        }

        //duration��_minDuration�ȉ��̏ꍇ�͑����ړ��Ƃ��ď���
        if (duration <= _minDuration)
        {
            Rewrite(newMapPos,isSync);
            return;
        }

        StartMoveSmoothly(newMapPos,duration,isSync);
    }
    public bool Moving { get { return _moving; } }//�ړ�����


    public int HierarchyIndex { get { return _hierarchyIndex; } }//���݂̊K�w�ԍ�
    public Map_A_Hierarchy CurrentHierarchy { get { return _hierarchies[_hierarchyIndex]; } }//���݂̊K�w
    public Maps_Hierarchies Hierarchies//�ړ�����K�w�ꗗ
    {
        get { return _hierarchies; } 
        set { _hierarchies = value; }
    }



    //�ʒu���̏�������(isSync�ňʒu�̓������邩�����߂��)
    public void Rewrite(MapVec newMapPos)//�ʒu�����̏�������(�񓯊�)
    {
        Rewrite(newMapPos, _hierarchyIndex, false);
    }

    public void Rewrite(MapVec newMapPos,bool isSync)//�ʒu�����̏�������(�������邩�����߂��)
    {
        Rewrite(newMapPos, _hierarchyIndex, isSync);
    }

    public void Rewrite(int newHierarchyIndex)//�K�w�����̏�������(�񓯊�)
    {
        Rewrite(_pos, newHierarchyIndex, false);
    }

    public void Rewrite(int newHierarchyIndex, bool isSync)//�K�w�����̏�������(�������邩�����߂��)
    {
        Rewrite(_pos, newHierarchyIndex, isSync);
    }

    public void Rewrite(MapVec newMapPos, int newHierarchyIndex)//�ʒu�ƊK�w�����̏�������(�񓯊�)
    {
        Rewrite(newMapPos, newHierarchyIndex, false);
    }

    public void Rewrite(MapVec newMapPos, int newHierarchyIndex, bool isSync)//�ʒu�ƊK�w�����̏�������(�������邩�����߂��)
    {
        if (_target == null || _hierarchies == null)
        {
            Debug.Log("�C���X�y�N�^�[�Őݒ肳��Ă��Ȃ��ӏ�������̂ŁA�ړ��Ɏ��s���܂����I");
            return;
        }

        //�ʒu���͈͊O��������x�����Ēe��
        if (!CurrentHierarchy.IsInRange(newMapPos))
        {
            Debug.Log(newMapPos + "�͔͈͊O�̈ʒu�Ȃ̂ŁA�ړ��Ɏ��s���܂����I");
            return;
        }

        //�K�w�ԍ����͈͊O��������x�����͈͓��Ɏ��߂�
        if (_hierarchyIndex < 0 || _hierarchyIndex >= _hierarchies.Length)
        {
            Debug.Log(_hierarchyIndex + "�͔͈͊O�̊K�w�ԍ��Ȃ̂ŁA�ړ��Ɏ��s���܂����I");
            return;
        }



        if(!isSync)//�������Ȃ��ʒu��񏑂�����
        {
            RewriteTrs(newMapPos, newHierarchyIndex);
        }
        else if(_myPhotonView==null)//�����͂���������PhotonView���ݒ肳��Ă��Ȃ�(���̏ꍇ�͌x�������o���āA�������Ȃ��ʒu��񏑂�����)
        {
            Debug.Log("PhotonView���ݒ肳��Ă��Ȃ��̂ŁA�񓯊��ړ��Ƃ��ď������܂��I");
            RewriteTrs(newMapPos, newHierarchyIndex);
        }
        else//��������ʒu��񏑂�����
        {
            _myPhotonView.RPC(nameof(RewriteTrs), RpcTarget.All, newMapPos, newHierarchyIndex);
        }
    }



    //private
    [PunRPC]
    void RewriteTrs(MapVec newMapPos, int newHierarchyIndex)
    {
        _hierarchyIndex = newHierarchyIndex;
        _pos = newMapPos;
        Vector3 newWorldPos = CurrentWorldPos;
        _target.position = newWorldPos;
    }

    void Start()
    {
        Rewrite(_pos, _hierarchyIndex,true);
    }

    private void Update()
    {
        UpdateMoveSmoothly();
    }

    private void OnValidate()
    {
        Rewrite(_pos, _hierarchyIndex,true);
    }
}
