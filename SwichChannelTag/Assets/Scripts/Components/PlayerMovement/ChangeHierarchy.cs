using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�v���C���[�̊K�w�ړ�����
//enabled��false�ɂ���΁A�{�^���������Ă��K�w�ړ����o���Ȃ����邱�Ƃ��o����

public class ChangeHierarchy : MonoBehaviour
{
    [Tooltip("�}�b�v��̈ʒu���")] [SerializeField] 
    MapTransform _mapTrs;

    public event Action<int> OnSwitchHierarchy_NewIndex;//�K�w�؂�ւ����ɌĂ΂��(�����ɐV�����K�w�ԍ�������`��)
    public event Action OnSwitchHierarchy;//�K�w�؂�ւ����ɌĂ΂��(�����Ȃ�)

    public bool IsMoved;//
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

        _mapTrs.Rewrite(newHierarchyIndex);

        OnSwitchHierarchy_NewIndex?.Invoke(newHierarchyIndex);
        OnSwitchHierarchy?.Invoke();

        IsMoved = true;
    }

    private void Start()
    {
        Init();
    }

    private void Init()//����������
    {
        _mapTrs = PlayersManager.GetComponentFromMinePlayer<MapTransform>();
        IsMoved = false;
    }
}
