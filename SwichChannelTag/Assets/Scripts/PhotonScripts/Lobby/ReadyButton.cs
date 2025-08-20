using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReadyButton : MonoBehaviour
{
    [SerializeField] TMP_Text selfText;
    [SerializeField] string unReadyText;
    [SerializeField] string readyText;

    //�v���C���[�������Q�Ƃ�n���Ă��炤
    GettingReady ownPlayerReady;
    public GameObject OwnPlayer
    {
        set { ownPlayerReady = value.GetComponent<GettingReady>(); }
    }

    private void Start()
    {
        if(selfText == null)
        {
            selfText = GetComponentsInChildren<TMP_Text>()[0];
        }
    }

    public void SwitchReady()
    {
        if (selfText == null) return;

        ownPlayerReady.SwitchReady();
        selfText.text = ownPlayerReady.IsReady ? readyText : unReadyText;
    }
}
