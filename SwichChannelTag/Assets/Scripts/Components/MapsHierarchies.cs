using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�S�Ă̊K�w�̃}�b�v�̊Ǘ�

public class MapsHierarchies : MonoBehaviour
{
    [Tooltip("�ړ��ł���K�w�ꗗ")][SerializeField] Map_A_Hierarchy[] _maps;

    public Map_A_Hierarchy this[int index]//�ړ��ł���K�w�ꗗ
    {
        get { return _maps[index]; }
    }

    public int Length { get { return _maps.Length; } }//�K�w�̐�
}
