using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�}�b�v�̈ʒu���(�ʒu�ƊK�w���\���̂Ƃ��Ă܂Ƃ߂�����)

[System.Serializable]
public struct MapPosInfo
{
    [Tooltip("�K�w�ԍ�")][SerializeField] int _hierarchyIndex;
    [Tooltip("�ʒu")][SerializeField] MapVec _pos;

    public int HierarchyIndex { get { return _hierarchyIndex; } }
    public MapVec Pos { get { return _pos; } }
}
