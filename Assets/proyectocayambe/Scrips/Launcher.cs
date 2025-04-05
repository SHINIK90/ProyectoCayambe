using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class NewMonoBehaviourScript : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;

    public Transform spawnPoint;

    void Start()
    {
        PhotonNetwork.JoinRandomOrCreateRoom();
    }


    public override void OnJoinedRoom()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);

        player.GetComponent<PhotonView>().RPC("SetNameText", RpcTarget.AllBuffered, PlayerPrefs.GetString("PlayerName"));
    }



}

