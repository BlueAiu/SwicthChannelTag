using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�K�w���ڂ��J�����̐؂�ւ�

public class SwitchHierarchyCamera : MonoBehaviour
{
    [Tooltip("�K�w���Ƃ̃J�������S�_\n�K�w�̌����ݒ肵�Ă�������")] [SerializeField] Transform[] _mapCenters;
    [Tooltip("�J����")] [SerializeField] CinemachineVirtualCamera _mapCamera;
    [SerializeField] ChangeHierarchy _changeHierarchy;
    [SerializeField] Maps_Hierarchies _maps_Hierarchies;
    [SerializeField] ScenePlayerManager _scenePlayerManager;
    

    public void Switch(int hierarchyIndex)//�ʂ��K�w�̐؂�ւ�
    {
        if (!IsValid_MapCentersLength()) return;

        if(!_maps_Hierarchies.IsInRange(hierarchyIndex))
        {
            Debug.Log("�͈͊O�̊K�w�ԍ��ł��I");
            return;
        }

        Transform currentHierarchy=_mapCenters[hierarchyIndex];

        _mapCamera.Follow=currentHierarchy;
        _mapCamera.LookAt=currentHierarchy;
    }



    private void Awake()
    {
        IsValid_MapCentersLength();
        _changeHierarchy.OnSwitchHierarchy_NewIndex += Switch;
    }

    private void Start()
    {
        InitCamera();
    }

    void InitCamera()//�J�����̏���������
    {
        //�v���C���[�̏����ʒu�ɃJ���������킹��
        MapTransform myMapTrs = _scenePlayerManager.MyComponent<MapTransform>();
        Switch(myMapTrs.HierarchyIndex);
    }

    bool IsValid_MapCentersLength()
    {
        if(_mapCenters.Length != _maps_Hierarchies.Length)
        {
            Debug.Log("�K�w�̐����A���S�_���ݒ肳��Ă��܂���I");
            return false;
        }

        return true;
    }
}
