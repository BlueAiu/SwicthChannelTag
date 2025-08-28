using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�v���C���[�̊K�w�ړ�����
//enabled��false�ɂ���΁A�{�^���������Ă��K�w�ړ����o���Ȃ����邱�Ƃ��o����

public class ChangeHierarchy : MonoBehaviour
{
    [SerializeField] MapTransform _mapTrs;

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

    void SwitchHierarchy(bool inc)
    {
        if (!enabled) return;

        int delta = inc ? 1 : -1;

        int newHierarchyIndex = MathfExtension.CircularWrapping_Delta(_mapTrs.HierarchyIndex, delta, _mapTrs.Hierarchies.Length - 1);

        _mapTrs.Rewrite(newHierarchyIndex,true);
    }

    private void Start()//enabled�̃`�F�b�N����\�������邽�߁A�킴�Ƌ��Start�֐���u���Ă�
    {
        
    }
}
