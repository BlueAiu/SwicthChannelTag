using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�}�b�v��ɏ�Q����u��(�e�X�g�p)

public class SetObstacle : MonoBehaviour
{
    [SerializeField] Map_A_Hierarchy _map;
    [SerializeField] GameObject _obstacleObject;
    [SerializeField] MapVec[] _obstaclePoses;
    
    void Start()
    {
        for(int i=0; i<_obstaclePoses.Length ;i++)
        {
            Vector3 pos = _map.MapToWorld(_obstaclePoses[i]);
            GameObject obstacleInstance = Instantiate(_obstacleObject);//��Q���I�u�W�F�N�g�𐶐�
            obstacleInstance.transform.position = pos;

            _map.Mass[_obstaclePoses[i]] = E_Mass.Obstacle;
        }
    }
}
