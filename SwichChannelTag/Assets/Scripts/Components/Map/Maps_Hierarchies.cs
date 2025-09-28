using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�S�Ă̊K�w�̃}�b�v�̊Ǘ�

public class Maps_Hierarchies : MonoBehaviour
{
    [Tooltip("�ړ��ł���K�w�ꗗ")][SerializeField] Map_A_Hierarchy[] _maps;

    public Map_A_Hierarchy this[int index]//�ړ��ł���K�w�ꗗ
    {
        get { return _maps[index]; }
    }

    public int Length { get { return _maps.Length; } }//�K�w�̐�

    public bool IsInRange(int hierarchyIndex)//�K�w�ԍ��݂̂��͈͓����𔻒�
    {
        return hierarchyIndex >= 0 && hierarchyIndex < _maps.Length;
    }
    public bool IsInRange(MapPos pos)//�K�w�ԍ��ƃ}�X���W�������͈͓����𔻒�
    {
        return IsInRange(pos.hierarchyIndex) && _maps[pos.hierarchyIndex].IsInRange(pos.gridPos);
    }
}
