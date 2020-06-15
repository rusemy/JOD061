using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnection : MonoBehaviourPunCallbacks
{
    private string gameVersion = "0.0.1";
    private string nickname = "Player";
    private string roomName = "JOD061";

    void Start()
    {
        Debug.Log("Conectando ao servidor...", this);
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.NickName = nickname + Random.Range(0, 9999);
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnConnectedToMaster() {
        Debug.Log("Conectado!", this);
        if (PhotonNetwork.CountOfRooms == 0) {         
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 4;
            PhotonNetwork.JoinOrCreateRoom(roomName, options, TypedLobby.Default);
        } else {
            PhotonNetwork.JoinRoom(roomName);
        }
    }
    
    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause) {
        Debug.Log("Desconectado! "+ cause.ToString());
    }

    public override void OnCreatedRoom() {
        Debug.Log("Criada a sala " + roomName);
        Debug.Log("Jogador " + PhotonNetwork.LocalPlayer.NickName + " entrou na sala " + roomName + " (" + PhotonNetwork.CurrentRoom.PlayerCount + ")");
    }

    public override void OnPlayerEnteredRoom(Player player){
        Debug.Log("Jogador " + PhotonNetwork.LocalPlayer.NickName + " entrou na sala " + roomName + " (" + PhotonNetwork.CurrentRoom.PlayerCount + ")");
    }

    public override void OnPlayerLeftRoom(Player player){
        Debug.Log("Jogador " + PhotonNetwork.LocalPlayer.NickName + " saiu da sala " + roomName + " (" + PhotonNetwork.CurrentRoom.PlayerCount + ")");
    }
}
