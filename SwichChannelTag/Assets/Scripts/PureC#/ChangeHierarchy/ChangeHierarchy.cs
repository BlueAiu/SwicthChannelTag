using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�K�w�؂�ւ�

[System.Serializable]
public class ChangeHierarchy
{
    [SerializeField] Map_A_Hierarchy[] _maps;

    public Map_A_Hierarchy[] Maps
    {
        get { return _maps; }
        set { _maps = value; }
    }

    public Map_A_Hierarchy Change_Index(ref int currentIndex, int newIndex)//Index�ŕς���}�b�v���w��
    {
        //�ԍ����͈͊O�̏ꍇ�͌x�����o��
        if(newIndex < 0 || newIndex >= _maps.Length)
        {
            Debug.Log("�K�w�ԍ����͈͊O�ł�");
            return null;
        }

        currentIndex = newIndex;
        return _maps[currentIndex];
    }

    public Map_A_Hierarchy Change_Delta(ref int currentIndex,int delta)//�ω��ʂŕς���}�b�v���w��
    {
        delta %= _maps.Length;

        currentIndex += delta;
        currentIndex = (currentIndex + _maps.Length) % _maps.Length;

        return _maps[currentIndex];
    }
}
