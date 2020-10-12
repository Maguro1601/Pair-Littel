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
        //Photonに接続できていなければ
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.ConnectUsingSettings();   //Photonに接続する
            Debug.Log("Photonに接続しました。");
            if (string.IsNullOrEmpty(PhotonNetwork.NickName))
            {
                PhotonNetwork.NickName = "player" + Random.Range(1, 99999);
            }
            SceneManager.LoadScene("Lobby");
        }
    }

    void OnGUI()
    {
        //ログインの状態を画面上に出力
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }
}
