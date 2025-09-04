using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[���g�̏����擾����(�v���C���[���ƂɎ��t����)

public class GetPlayerInfo : MonoBehaviour
{
    Dictionary<System.Type, Component> _cache = new();//�L���b�V��


    //�v���C���[�̃R���|�[�l���g���擾
    public T GetComp<T>() where T : Component
    {
        System.Type type = typeof(T);//�^�����o��

        //�L���b�V�����瓯���^��T���A�Ȃ������畁�ʂ�GetComponent
        if(!_cache.TryGetValue(type, out Component ret))
        {
            ret=GetComponent<T>();

            //null����Ȃ���΃L���b�V���ɓo�^
            if(ret!=null)
            {
                _cache[type]=ret;
            }
        }

        return ret as T;
    }
}
