using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class CGameManager : MonoBehaviourPunCallbacks
{
    //誰かがログインする度に生成するプレイヤーPrefab
    public GameObject playerPrefab;
    public GameObject playerPrefab2;
    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.IsConnected)   //Phootnに接続されていなければ
        {
            SceneManager.LoadScene("Launcher"); //ログイン画面に戻る
            return;
        }
        //Photonに接続していれば自プレイヤーを生成
        if (PhotonNetwork.PlayerList.Length == 1)
        {
            GameObject Player = PhotonNetwork.Instantiate(this.playerPrefab.name, new Vector3(16f, 14f, 4f), Quaternion.Euler(0,-90,0), 0);
        }
        else
        {
            GameObject Player2 = PhotonNetwork.Instantiate(this.playerPrefab2.name, new Vector3(16f, 14f, 4f), Quaternion.Euler(0,-90,0), 0);
        }
       
    }

    void OnGUI()
    {
        //ログインの状態を画面上に出力
        GUILayout.Label(PhotonNetwork.NetworkClientState.ToString());
    }
}
