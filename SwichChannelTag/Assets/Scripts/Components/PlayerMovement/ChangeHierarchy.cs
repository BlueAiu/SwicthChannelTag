using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�v���C���[�̊K�w�ړ�����
//enabled��false�ɂ���΁A�{�^���������Ă��K�w�ړ����o���Ȃ����邱�Ƃ��o����

public class ChangeHierarchy : MonoBehaviour
{
    [Tooltip("�V�[�����̃v���C���[�̏����擾����@�\")] [SerializeField] 
    ScenePlayerManager _scenePlayerManager;

    [Tooltip("�}�b�v��̈ʒu���")] [SerializeField] 
    MapTransform _mapTrs;

    public void SwitchHierarchy_Inc(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        SwitchHierarchy(true);
    }

    public void SwitchHierarchy_Dec(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        SwitchHierarchy(false);
    }



    //private
    void SwitchHierarchy(bool inc)
    {
        if (!enabled) return;

        int delta = inc ? 1 : -1;

        int newHierarchyIndex = MathfExtension.CircularWrapping_Delta(_mapTrs.HierarchyIndex, delta, _mapTrs.Hierarchies.Length - 1);

        _mapTrs.Rewrite(newHierarchyIndex,true);
    }

    private void Start()
    {
        Init();
    }

    private void Init()//����������
    {
        if (_scenePlayerManager != null) _mapTrs = _scenePlayerManager.MyComponent<MapTransform>();
        else if (_mapTrs == null) Debug.Log("���̂܂܂��ƃv���C���[�������܂���I");
    }
}
