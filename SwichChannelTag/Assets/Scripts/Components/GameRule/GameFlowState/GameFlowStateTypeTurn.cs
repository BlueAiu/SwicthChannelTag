using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowStateTypeTurn : GameFlowStateTypeBase
{
    EPlayerState turnSide;
    PlayerTurnFlow[] players;

    List<PlayerTurnFlow> ownPlayers;


    public GameFlowStateTypeTurn(EPlayerState turnSide, PlayerTurnFlow[] players)
    {
        this.turnSide = turnSide;
        this.players = players;
    }

    public override void OnEnter()//�X�e�[�g�̊J�n����
    {
        foreach (var player in this.players)
        {
            player.StartTurn(turnSide);

            if(player.PlayerState == turnSide)
            {
                ownPlayers.Add(player);
            }
        }
    }

    public override void OnUpdate()//�X�e�[�g�̖��t���[������
    {
        bool isFinishAll = true;
        foreach (var player in ownPlayers)
        {
            isFinishAll &= player.IsTurnFinished;
        }

        if (isFinishAll) this._finished = true;
    }

    public override void OnExit()//�X�e�[�g�̏I������
    {
        // Pass
    }
}
