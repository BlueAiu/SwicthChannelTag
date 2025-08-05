using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

//�쐬��:���R
//�}�b�v�̃x�N�g��(�\����)�̒�`

[System.Serializable]
public struct MapVec
{

    //�t�B�[���h
    public int x;//x���̈ʒu
    public int y;//y���̈ʒu
    
    public MapVec(int x,int y)
    {
        this.x = x;
        this.y = y;
    }


    //�����x�N�g����Ԃ�
    public static MapVec Direction(E_MapDirection direction)
    {
        switch(direction)
        {
            case E_MapDirection.Up: return new MapVec(0, 1);//��
            case E_MapDirection.Right: return new MapVec(1, 0);//�E
            case E_MapDirection.Down: return new MapVec(0, -1);//��
            case E_MapDirection.Left: return new MapVec(-1, 0);//��
            default: return new MapVec(0,0);
        }
    }


    //���Z�q
   
    public static MapVec operator +(MapVec vec1, MapVec vec2)// + ���Z�q�̃I�[�o�[���[�h
    {
        return new MapVec(vec1.x + vec2.x, vec1.y + vec2.y);
    }

    public static MapVec operator -(MapVec vec1, MapVec vec2)// - ���Z�q�̃I�[�o�[���[�h
    {
        return new MapVec(vec1.x - vec2.x, vec1.y - vec2.y);
    }

    public static MapVec operator *(MapVec vec1,int rate)// * ���Z�q�̃I�[�o�[���[�h
    {
        return new MapVec(vec1.x * rate, vec1.y * rate);
    }

    public static MapVec operator *(int rate,MapVec vec1)// * ���Z�q�̃I�[�o�[���[�h
    {
        return vec1 * rate;
    }

    public static bool operator ==(MapVec vec1, MapVec vec2)//==���Z�q�I�[�o�[���[�h
    {
        return (vec1.x == vec2.x) && (vec1.y == vec2.y);
    }

    public static bool operator !=(MapVec vec1, MapVec vec2)//!=���Z�q�I�[�o�[���[�h
    {
        return !(vec1 == vec2);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is MapVec)) return false;
        MapVec other = (MapVec)obj;
        return this == other;
    }

    public override int GetHashCode()
    {
        return System.HashCode.Combine(x, y);
    }
}