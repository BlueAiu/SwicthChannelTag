using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void StartMoveSmoothly(MapVec newMapPos, float duration)
    {
        _moving = true;
        _endMapPos = newMapPos;
        _moveDuration = duration;
        _currentMoveTime = 0;//���݂̎��Ԃ�������
        RewritePos(Pos, HierarchyIndex);//�ʒu�����݂̈ʒu�ɏ�����

        //�n�_�A�I�_�̃��[���h���W��ݒ�
        _startWorldPos = CurrentHierarchy.MapToWorld(Pos);
        _endWorldPos=CurrentHierarchy.MapToWorld(_endMapPos);
    }

    void UpdateMoveSmoothly()
    {
        if (!_moving) return;

        //���ԍX�V
        _currentMoveTime += Time.deltaTime;

        //�^�[�Q�b�g�̃��[���h���W�����񂾂�Ǝn�_����I�_�܂ŋ߂Â��Ă���
        float rate = _currentMoveTime/_moveDuration;
        Vector3 newWorldPos = Vector3.Lerp(_startWorldPos, _endWorldPos, rate);
        _target.transform.position = newWorldPos;

        //���Ԃ��߂�����ړ����I����
        if(_currentMoveTime>=_moveDuration) EndMoveSmoothly();
    }

    void EndMoveSmoothly()
    {
        _moving=false;
        RewritePos(_endMapPos, HierarchyIndex);//�ʒu���I�_�̈ʒu�ɏ�������
    }
}
