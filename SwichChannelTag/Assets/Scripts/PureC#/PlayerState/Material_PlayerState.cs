using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

//�쐬��:���R
//�v���C���[�̏�Ԃɉ����ă}�e���A����؂�ւ���

[System.Serializable]
public class Material_PlayerState
{
    [Tooltip("�S�̃}�e���A��")] [SerializeField]
    Material _taggerMaterial;

    [Tooltip("�����̃}�e���A��")] [SerializeField]
    Material _runnerMaterial;

    [Tooltip("�v���C���[�̃��b�V��")] [SerializeField]
    MeshRenderer _mesh;

    public void ChangeMaterial(EPlayerState newState)
    {
        if (!Enum.IsDefined(typeof(EPlayerState), newState) || newState == EPlayerState.Length)//�l�`�F�b�N(�ُ킠������x�����ď�����e��)
        {
            Debug.Log("���݂��Ȃ���Ԃł�");
            return;
        }

        //�}�e���A���̕ύX
        switch (newState)
        {
            case EPlayerState.Runner://����
                _mesh.material = _runnerMaterial;
                break;

            case EPlayerState.Tagger://�S
                _mesh.material = _taggerMaterial;
                break;
        }
    }
}
