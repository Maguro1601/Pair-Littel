using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SceneScript : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        var v = new Vector3(Random.Range(-3f,3f), 0, 0);
        PhotonNetwork.Instantiate("unitychan", v, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
