using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor.Experimental.GraphView;

//�쐬��:���R
//�}�b�v�����u�ňړ�����̂ł͂Ȃ��A�X���[�Y�Ɉړ�

public partial class MapTransform
{
    bool _moving=false;
    const float _minDuration = 0;

    Vector3 _startWorldPos;//�n�_�̃��[���h���W
    Vector3 _endWorldPos;//�I�_�̃��[���h���W

    MapVec _endMapPos;//�I�_�̃}�b�v��̈ʒu

    float _moveDuration;//�����̂ɂ����鎞��
    float _currentMoveTime;//���݂̎���

    bool _isSync;//�ړ����ɓ��������邩

    void StartMoveSmoothly(MapVec newMapPos, float duration,bool isSync)
    {
        if (isSync) _myPhotonView.RPC(nameof(InitProcess), RpcTarget.All);
        else InitProcess(newMapPos,duration,isSync);
    }

    void UpdateMoveSmoothly()
    {
        if (!_moving) return;

        if (_isSync && !_myPhotonView.IsMine) return;//�����ړ��̏ꍇ�A�����̂łȂ��Ȃ�ʒu�̌v�Z���������Ȃ�

        //���ԍX�V
        _currentMoveTime += Time.deltaTime;

        //�^�[�Q�b�g�̃��[���h���W�����񂾂�Ǝn�_����I�_�܂ŋ߂Â��Ă���
        float rate = _currentMoveTime/_moveDuration;
        Vector3 newWorldPos = Vector3.Lerp(_startWorldPos, _endWorldPos, rate);

        //����������ꍇ�͈ʒu�̏������������̂ݓ���������
        if (_isSync) _myPhotonView.RPC(nameof(UpdateTargetPos), RpcTarget.All);
        else UpdateTargetPos(newWorldPos);

        //���Ԃ��߂�����ړ����I����
        if(_currentMoveTime>=_moveDuration) EndMoveSmoothly();
    }

    void EndMoveSmoothly()
    {
        if (_isSync) _myPhotonView.RPC(nameof(ExitProcess), RpcTarget.All);
        else ExitProcess();
    }


    [PunRPC]
    void InitProcess(MapVec newMapPos, float duration, bool isSync)
    {
        _isSync = isSync;
        _moving=true;
        _endMapPos = newMapPos;
        _moveDuration = duration;
        _currentMoveTime = 0;//���݂̎��Ԃ�������
        Rewrite(Pos, HierarchyIndex);//�ʒu�����݂̈ʒu�ɏ�����

        //�n�_�A�I�_�̃��[���h���W��ݒ�
        _startWorldPos = CurrentHierarchy.MapToWorld(Pos);
        _endWorldPos = CurrentHierarchy.MapToWorld(_endMapPos);
    }

    [PunRPC]
    void UpdateTargetPos(Vector3 newWorldPos)//�ʒu��������������(�v�Z�Ƃ��͎����������΂���)
    {
        _target.transform.position = newWorldPos;
    }

    [PunRPC]
    void ExitProcess()
    {
        _moving = false;
        Rewrite(_endMapPos, HierarchyIndex);//�ʒu���I�_�̈ʒu�ɏ�������
    }

}
