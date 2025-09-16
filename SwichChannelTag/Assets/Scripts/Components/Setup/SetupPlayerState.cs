using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�̋S�E�����̏�����
//���̂Ƃ���A�v���C���[�̒����烉���_���ɋS����l�I�o

public class SetupPlayerState : MonoBehaviour
{
    void Start()
    {
        SelectTagger();
    }

    void SelectTagger()//�S�����߂�
    {
        //�Q���҂̒����烉���_���Ɉ�l�I�o���āA�I�΂ꂽ�l���S�ɂ���
        PlayerState[] players = PlayersManager.GetComponentsFromPlayers<PlayerState>();

        int taggerIndex=Random.Range(0, players.Length);

        players[taggerIndex].ChangeState(EPlayerState.Tagger);
    }
}
