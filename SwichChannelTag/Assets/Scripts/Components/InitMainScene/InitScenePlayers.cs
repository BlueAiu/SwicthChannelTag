using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�V�[���J�n���Ƀv���C���[�B�̃R���|�[�l���g�̏������������s��

public class InitScenePlayers : MonoBehaviour
{
    [Tooltip("�ړ��ł���K�w�ꗗ")][SerializeField] 
    Maps_Hierarchies _hierarchies;

    void Start()
    {
        InitMapTrs();
    }

    void InitMapTrs()//�S�v���C���[��MapTransform�̏�����
    {
        MapTransform[] mapTrses = PlayersManager.GetComponentsFromPlayers<MapTransform>();

        for(int i=0; i<mapTrses.Length;i++)
        {
            MapTransform mapTrs = mapTrses[i];
            if (mapTrs != null) mapTrs.Hierarchies = _hierarchies;
            mapTrs.Rewrite(mapTrs.Pos, mapTrs.HierarchyIndex, true);//�ʒu��������
        }
    }
}
