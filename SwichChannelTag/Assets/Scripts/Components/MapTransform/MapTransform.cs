using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

//�쐬��:���R
//�L�����̃}�b�v��̈ʒu���(�}�b�v��̈ʒu�ƃ��[���h��̈ʒu�𓯊�������)
//PhotonView��ݒ肷�邱�ƂŁA�ʒu��ʐM���������邱�Ƃ��\(�t�ɒʐM���������Ɉړ������邱�Ƃ��\)

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
        CheckAbleToSync(ref isSync);//�����o���邩�`�F�b�N(�o���Ȃ��̂ł���΁A�񓯊��ړ��ɕύX)

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
    public void Rewrite(MapVec newMapPos, bool isSync=false)//�ʒu�����̏�������(�񓯊�)
    {
        Rewrite(newMapPos, _hierarchyIndex, isSync);
    }

    public void Rewrite(int newHierarchyIndex, bool isSync = false)//�K�w�����̏�������(�񓯊�)
    {
        Rewrite(_pos, newHierarchyIndex, isSync);
    }

    public void Rewrite(MapVec newMapPos, int newHierarchyIndex, bool isSync=false)//�ʒu�ƊK�w�����̏�������(�������邩�����߂��)
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

        //�K�w�ԍ����͈͊O��������x�����Ēe��
        if (newHierarchyIndex < 0 || newHierarchyIndex >= _hierarchies.Length)
        {
            Debug.Log(_hierarchyIndex + "�͔͈͊O�̊K�w�ԍ��Ȃ̂ŁA�ړ��Ɏ��s���܂����I");
            return;
        }

        CheckAbleToSync(ref isSync);//�����o���邩�`�F�b�N(�o���Ȃ��̂ł���΁A�񓯊��ړ��ɕύX)

        if (isSync) _myPhotonView.RPC(nameof(RewriteTrs), RpcTarget.All, newMapPos.x, newMapPos.y, newHierarchyIndex);//��������ʒu��񏑂�����
        else RewriteTrs(newMapPos.x,newMapPos.y, newHierarchyIndex);//�������Ȃ��ʒu��񏑂�����
    }


    //private

    [PunRPC]//Photon���g�����ꍇ�AMapVec�����̂܂܈����ɓ����ƃG���[�ɂȂ�̂ŁAint�œn��
    void RewriteTrs(int newMapPos_X,int newMqpPos_Y, int newHierarchyIndex)
    {
        MapVec newMapPos=new MapVec(newMapPos_X,newMqpPos_Y);
        _hierarchyIndex = newHierarchyIndex;
        _pos = newMapPos;
        Vector3 newWorldPos = CurrentWorldPos;
        _target.position = newWorldPos;
    }

    void CheckAbleToSync(ref bool isSync)
    {
        if (isSync && _myPhotonView == null)//�������������ǁA�����ɕK�v��PhotonView�������ꍇ�A�񓯊��Ƃ��Ĉ����悤�ɂ���
        {
            Debug.Log("PhotonView���ݒ肳��Ă��Ȃ��̂ŁA���������ɏ������܂��I");
            isSync = false;
        }
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
