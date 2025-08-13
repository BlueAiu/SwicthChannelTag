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
    

    public Map_A_Hierarchy Map//�ǂ̃}�b�v��𓮂���
    {
        get { return _map; }
    }

    public Transform Target//�������Ώ�
    {
        get { return _target; }
    }

    public bool Move(ref MapVec currentPos,Vector2 inputVec)//�w������Ɉړ�(�ړ��Ɏ��s������false��Ԃ�)
    {
        MapVec moveVec;
        moveVec.x = (int)inputVec.x;
        moveVec.y = -(int)inputVec.y;

        MapVec newPos = currentPos + moveVec;

        if (!_map.IsInRange(newPos) || _map.Mass[newPos] != E_Mass.Empty) return false;//�ړ��ł��Ȃ��ꍇ

        RewritePos(out currentPos,newPos);
        return true;
    }

    public void RewritePos(out MapVec currentPos, MapVec newMapVec,Map_A_Hierarchy newMap)//�ʒu�ƃ}�b�v�̏�������(���[�v�I�Ȃ��)
    {
        _map = newMap;
        RewritePos(out currentPos, newMapVec);
    }

    public void RewritePos(out MapVec currentPos,MapVec newMapVec)//�ʒu�̏�������(���[�v�I�Ȃ��)
    {
        currentPos = _map.ClampInRange(newMapVec);//�͈͊O�ɂ͂ݏo���Ȃ����u��������(��}�X�̔���͂��Ȃ�)
        Vector3 newPos = _map.MapToWorld(currentPos);
        _target.position = newPos;
    }
}
