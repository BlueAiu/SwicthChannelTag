using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�}�b�v��ɏ�Q����u��(�e�X�g�p)

public class SetObstacle : MonoBehaviour
{
    [SerializeField] Maps_Hierarchies _map;
    [SerializeField] GameObject _obstacleObject;
    [SerializeField] MapPos[] _obstaclePoses;
    
    void Start()
    {
        for(int i=0; i<_obstaclePoses.Length ;i++)
        {
            MapPos _obstaclePos = _obstaclePoses[i];

            //�͈͊O�ł���΁A�������s
            if (!_map.IsInRange(_obstaclePos.hierarchyIndex,_obstaclePos.pos))
            {
                Debug.Log("�͈͊O�Ȃ̂Ő������s");
                continue;
            }
            
            Map_A_Hierarchy map = _map[_obstaclePos.hierarchyIndex];

            Vector3 pos = map.MapToWorld(_obstaclePos.pos);
            GameObject obstacleInstance = Instantiate(_obstacleObject);//��Q���I�u�W�F�N�g�𐶐�
            obstacleInstance.transform.position = pos;

            map.Mass[_obstaclePos.pos] = E_Mass.Obstacle;
        }
    }
}
