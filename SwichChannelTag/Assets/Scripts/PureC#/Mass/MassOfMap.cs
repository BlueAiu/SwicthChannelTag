using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�}�b�v���Ƃ̏����i�[����


public class MassOfMap
{
    private E_Mass[,] _mass;

    public MassOfMap(int size_X,int size_Y)
    {
        //�}�X�̃T�C�Y�̊m��
        _mass = new E_Mass[size_Y, size_X];

        //�S�Ẵ}�X����ɂ���
        for(int i=0; i<_mass.GetLength(0) ;i++)
        {
            for(int j=0; j<_mass.GetLength(1) ;j++)
            {
                _mass[i, j] = E_Mass.Empty;
            }
        }
    }

    
}
