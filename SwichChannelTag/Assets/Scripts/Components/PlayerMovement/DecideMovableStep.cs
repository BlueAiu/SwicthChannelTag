using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R
//������}�X�������߂�

public class DecideMovableStep : MonoBehaviour
{
    [SerializeField] SerializeDice _defaultDice;
    [SerializeField] SerializableDictionary<EPlayerState, SerializeDice> _switchedDice;
    [SerializeField] MoveOnMap _moveOnMap;
    [SerializeField] TextMeshProUGUI _diceResultText;

    public void Dicide()//������}�X��������(�_�C�X���[����)
    {
        int result;

        bool dummy = true;
        EPlayerState dummyState = EPlayerState.Runner;
        if (dummy)
        {
            if(_switchedDice.TryGetValue(dummyState, out var dice))
            {
                result = dice.DiceRoll();
            }
            else
            {
                Debug.LogWarning("Not found switchedDice in " + dummyState);
                result = 0;
            }
        }
        else
        {
            result = _defaultDice.DiceRoll();
        }

        _moveOnMap.RemainingStep=result;
    }

    private void Update()
    {
        _diceResultText.text = _moveOnMap.RemainingStep.ToString();//�e�L�X�g�Ɏc��ړ��\�}�X����\��
    }
}
