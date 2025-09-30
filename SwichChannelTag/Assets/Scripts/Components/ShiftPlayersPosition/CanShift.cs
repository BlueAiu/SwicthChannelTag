using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�ʒu�����炵�Ă��悢��

public class CanShift : MonoBehaviour
{
    [SerializeField]
    PhotonView _myPhotonView;

    bool _isShiftAllowed = true;

    public bool IsShiftAllowed//���炵�Ă��悢��
    { 
        get { return _isShiftAllowed; } 
        set { _myPhotonView.RPC(nameof(SetIsShiftAllowed), RpcTarget.All, value); }
    }

    [PunRPC]
    void SetIsShiftAllowed(bool value)
    {
        _isShiftAllowed=value;
    }
}
