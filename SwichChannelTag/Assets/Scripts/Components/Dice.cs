using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�쐬��:���R
//�_�C�X������

public class Dice : MonoBehaviour
{
    [Tooltip("�_�C�X�̍ő�l(1�`MaxNum�ȉ��̒l���o��)")] [SerializeField] int _maxNum;
    [SerializeField] TextMeshProUGUI _diceResultText;
    int _minNum=1;

    public void DiceRoll()
    {
        int result=Random.Range(_minNum, _maxNum+1);
        _diceResultText.text = result.ToString();
    }
}
