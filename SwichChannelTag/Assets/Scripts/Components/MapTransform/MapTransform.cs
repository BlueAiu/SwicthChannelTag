using UnityEngine;
using Photon.Pun;

//�쐬��:���R
//�L�����̃}�b�v��̈ʒu���
//PhotonView��ݒ肷�邱�ƂŁA�ʒu��ʐM���������邱�Ƃ��\(�t�ɒʐM���������Ɉړ������邱�Ƃ��\)

public partial class MapTransform : MonoBehaviour
{
    [Tooltip("�ړ��ł���K�w�ꗗ")][SerializeField] Maps_Hierarchies _hierarchies;
    [SerializeField] PhotonView _myPhotonView;
    [SerializeField] MapPos _pos;//���W


    public MapPos Pos { get { return _pos; } }//���W

    public Vector3 CurrentWorldPos//���ݗ����Ă���}�X�̒��S�_
    {
        get 
        {
            if(_hierarchies==null)
            {
                Debug.Log("Hierarchies���ݒ肳��Ă��܂���I");
                return Vector3.zero;
            }

            return CurrentHierarchy.MapToWorld(_pos.gridPos); 
        }
    }

    public Map_A_Hierarchy CurrentHierarchy //���݂̊K�w
    {
        get
        {
            if(_hierarchies==null)
            {
                Debug.Log("Hierarchies���ݒ肳��Ă��܂���I");
                return null;
            }

            return _hierarchies[_pos.hierarchyIndex]; 
        } 
    }

    public Maps_Hierarchies Hierarchies//�ړ�����K�w�ꗗ
    {
        get { return _hierarchies; } 
        set { _hierarchies = value; }
    }

    //�ʒu���̏�������(isSync�ňʒu�̓������邩�����߂��)
    public void Rewrite(MapVec newGridPos, bool isSync=true)//�ʒu�����̏�������
    {
        Rewrite(new MapPos(_pos.hierarchyIndex, newGridPos),isSync);
    }

    public void Rewrite(int newHierarchyIndex, bool isSync = true)//�K�w�����̏�������
    {
        Rewrite(new MapPos(newHierarchyIndex, _pos.gridPos),isSync);
    }

    public void Rewrite(MapPos newPos, bool isSync=true)//�ʒu�ƊK�w�����̏�������
    {
        if (_hierarchies == null)
        {
            Debug.Log("�C���X�y�N�^�[�Őݒ肳��Ă��Ȃ��ӏ�������̂ŁA�ړ��Ɏ��s���܂����I");
            return;
        }

        //�ʒu���͈͊O��������x�����Ēe��
        if (!_hierarchies.IsInRange(newPos))
        {
            Debug.Log(newPos + "�͔͈͊O�Ȃ̂ŁA�ړ��Ɏ��s���܂����I");
            return;
        }

        CheckAbleToSync(ref isSync);//�����o���邩�`�F�b�N(�o���Ȃ��̂ł���΁A�񓯊��ړ��ɕύX)

        if (isSync) _myPhotonView.RPC(nameof(RewriteTrs), RpcTarget.All, newPos.gridPos.x, newPos.gridPos.y, newPos.hierarchyIndex);//��������ʒu��񏑂�����
        else RewriteTrs(newPos.gridPos.x,newPos.gridPos.y, newPos.hierarchyIndex);//�������Ȃ��ʒu��񏑂�����
    }


    //private

    [PunRPC]//Photon���g�����ꍇ�AMapVec�����̂܂܈����ɓ����ƃG���[�ɂȂ�̂ŁAint�œn��
    void RewriteTrs(int newGridPos_X,int newGridPos_Y, int newHierarchyIndex)
    {
        MapVec newGridPos=new MapVec(newGridPos_X,newGridPos_Y);

        MapPos newPos = new MapPos(newHierarchyIndex, newGridPos);
        _pos = newPos;
    }

    void CheckAbleToSync(ref bool isSync)
    {
        if (isSync && _myPhotonView == null)//�������������ǁA�����ɕK�v��PhotonView�������ꍇ�A�񓯊��Ƃ��Ĉ����悤�ɂ���
        {
            Debug.Log("PhotonView���ݒ肳��Ă��Ȃ��̂ŁA���������ɏ������܂��I");
            isSync = false;
        }
    }
}
