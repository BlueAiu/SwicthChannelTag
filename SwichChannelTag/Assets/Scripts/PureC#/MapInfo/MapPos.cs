using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�}�b�v�̈ʒu���(�ʒu�ƊK�w���\���̂Ƃ��Ă܂Ƃ߂�����)

[System.Serializable]
public struct MapPos
{
    public int hierarchyIndex;//�K�w�ԍ�
    public MapVec pos;//�ʒu

    public MapPos(int hierarchyIndex, MapVec pos)
    {
        this.hierarchyIndex = hierarchyIndex;
        this.pos = pos;
    }


    //���Z�q
    public static bool operator ==(MapPos pos1, MapPos pos2)//==���Z�q�I�[�o�[���[�h
    {
        return (pos1.hierarchyIndex == pos2.hierarchyIndex) && (pos1.pos == pos2.pos);
    }

    public static bool operator !=(MapPos pos1, MapPos pos2)//!=���Z�q�I�[�o�[���[�h
    {
        return !(pos1 == pos2);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is MapPos)) return false;
        MapPos other = (MapPos)obj;
        return this == other;
    }

    public override int GetHashCode()
    {
        return System.HashCode.Combine(hierarchyIndex, pos);
    }
}
