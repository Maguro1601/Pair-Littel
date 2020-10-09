using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;
using Photon.Realtime;


public class CPlayerManager : MonoBehaviourPunCallbacks, IPunObservable
{
    public GameObject PlayerUiPrefab;
    public static GameObject LocalPlayerInstance;

    void Awake()
    {
        if (photonView.IsMine)
        {
            CPlayerManager.LocalPlayerInstance = this.gameObject;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine) //このオブジェクトがLocalでなければ実行しない
        {
            return;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {

    }
}
