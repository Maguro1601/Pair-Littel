using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPlayerUIScript : MonoBehaviour
{
    public Text PlayerNameText;
    public CPlayerManager _target;
    Vector3 _targetPosition;

    void Update()
    {

    }

    void LateUpdate()
    {
        //　カメラと同じ向きに設定
        transform.rotation = Camera.main.transform.rotation;
    }

    public void SetTarget(CPlayerManager target)
    {
        if (target == null)//targetがいなければエラーをConsoleに表示
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
            return;
        }
        //targetの情報をこのスクリプト内で使うのでコピー
        _target = target;

        if (PlayerNameText != null)
        {
            PlayerNameText.text = _target.photonView.Owner.NickName;
        }

    }
}
