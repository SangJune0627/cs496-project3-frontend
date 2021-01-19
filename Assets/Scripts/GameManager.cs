﻿using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<GameManager>();

            return instance;
        }
    }

    private static GameManager instance;
    public Transform[] spawnPositions;
    public GameObject playerPrefab;
    private void Start()
    {
        SpawnPlayer();

        if (PhotonNetwork.IsMasterClient)
        {
            // SpawnBall();
        }
    }

    private void SpawnPlayer()
    {
        var localPlayerIndex = PhotonNetwork.LocalPlayer.ActorNumber - 1;
        var spawnPosition = spawnPositions[localPlayerIndex % spawnPositions.Length];
        Debug.Log(spawnPosition);
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition.position, Quaternion.identity);
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene("Lobby");
    }
}