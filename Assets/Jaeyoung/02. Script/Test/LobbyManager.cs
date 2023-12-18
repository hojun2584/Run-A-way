using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public LobbyManager instance;
    [SerializeField] GameObject characterPrafab;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] Image[] playerImage = new Image[4];
    public int playerCount;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        
        DontDestroyOnLoad(this.gameObject);
        PhotonNetwork.ConnectUsingSettings();
    }
    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
            PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }
    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("���� �Ϸ�");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("���� ����");
    }


    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = playerCount;
        PhotonNetwork.CreateRoom(null, roomOptions);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("���� �濡 ���Խ��ϴ�.");
        SetActivePlayerImage();
        PhotonNetwork.Instantiate(characterPrafab.name, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + "�濡 ���Խ��ϴ�.");
        SetActivePlayerImage();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + "�濡�� �������ϴ�.");
        SetActivePlayerImage();
    }

    private void SetActivePlayerImage()
    {
        for (int i = 0; i < PhotonNetwork.CurrentRoom.MaxPlayers; i++)
        {
            playerImage[i].gameObject.SetActive(i < PhotonNetwork.CurrentRoom.PlayerCount);
        }
    }
}
