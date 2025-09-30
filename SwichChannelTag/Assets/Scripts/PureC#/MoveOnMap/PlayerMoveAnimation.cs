using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�̈ړ��̗l�q

public class PlayerMoveAnimation : MonoBehaviour
{
    [Tooltip("��̃}�X�̈ړ��ɂ����鎞��")] [SerializeField]
    float _moveDuration;

    Transform _myTrs;

    const float _defaultCurrentTime = 0;
    float _currentTime;

    bool _isMoving = false;

    public bool IsMoving {  get { return _isMoving; } } 

    public void StartMove(Vector3 start,Vector3 destination)
    {
        if(_isMoving)
        {
            Debug.Log("�ړ����ł�");
            return;
        }

        StartCoroutine(Move(start,destination));
    }

    IEnumerator Move(Vector3 start, Vector3 destination)
    {
        _isMoving = true;
        _myTrs.position = start;
        _currentTime = _defaultCurrentTime;

        while(_currentTime<=_moveDuration)
        {
            _currentTime += Time.deltaTime;
            float rate = _currentTime / _moveDuration;
            Vector3 newWorldPos = Vector3.Lerp(start, destination, rate);
            _myTrs.position = newWorldPos;

            yield return null;
        }

        _myTrs.position = destination;
        _isMoving = false;
    }

    private void Awake()
    {
        Init();
    }

    private void Init()//������
    {
        _myTrs = PlayersManager.GetComponentFromMinePlayer<Transform>();
    }
}
