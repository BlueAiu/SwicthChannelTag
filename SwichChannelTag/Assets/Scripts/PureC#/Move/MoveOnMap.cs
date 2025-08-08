using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�}�b�v����ړ�����

[System.Serializable]
public class MoveOnMap
{
    [Tooltip("�ǂ̃}�b�v��𓮂���")] [SerializeField] Map_A_Hierarchy _map;
    [Tooltip("�������Ώ�")] [SerializeField] Transform _target;
    [Tooltip("�����ʒu")][SerializeField] MapVec _startPoint;

    private MapVec _currentPos;

    public Map_A_Hierarchy Map//�ǂ̃}�b�v��𓮂���
    {
        get { return _map; }
        set { _map = value; }
    }

    public Transform Target//�������Ώ�
    {
        get { return _target; }
        set { _target = value; }
    }

    public MapVec CurrentPos { get { return _currentPos; } }//���݂̈ʒu

    public void Start()//Start�֐��ŌĂяo��
    {
        //�ʒu�̏�����
        RewritePos(_startPoint);
    }

    public bool Move(Vector2 inputVec)//�ړ�(�ړ��Ɏ��s������false��Ԃ�)
    {
        MapVec moveVec;
        moveVec.x = (int)inputVec.x;
        moveVec.y = (int)inputVec.y;

        MapVec newPos = _currentPos + moveVec;

        if (!_map.IsInRange(newPos)) return false;//�ړ��ł��Ȃ��ꍇ

        RewritePos(newPos);
        return true;
    }

    void RewritePos(MapVec newMapVec)//�ʒu�̏�������
    {
        _currentPos = _map.ClampInRange(newMapVec);//�͈͊O�̈ʒu�ɍs���Ȃ��悤�ɂ��邽�߂̏��u
        Vector3 newPos = _map.MapToWorld(_currentPos);
        _target.position = newPos;
    }
}
