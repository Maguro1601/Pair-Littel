using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class CLauncherScript : MonoBehaviourPunCallbacks
{
    public void Connect()
    {
        if (!PhotonNetwork.IsConnected)
        {           //Photonに接続できていなければ
            PhotonNetwork.ConnectUsingSettings();   //Photonに接続する
            Debug.Log("Photonに接続しました。");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMasterが呼ばれました");
        // "room"という名前のルームに参加する（ルームが無ければ作成してから参加する）
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("ルームに入りました。");
        //Mainシーンをロード
        PhotonNetwork.LoadLevel("Main");
    }
}
