using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�L�����̓����R���|�[�l���g(�e�X�g�p)

public class MoveOnMap : MonoBehaviour
{
    [SerializeField] Map_A_Hierarchy _map;
    [SerializeField] MapVec _startPoint;

    void Start()
    {
        //�ʒu�̏�����
        Vector3 startVec;
        _map.Transit_FromMapVec_ToWorldVec(_startPoint, out startVec);

        transform.position = startVec;
    }

    private void Move()
    {
        
    }
}
