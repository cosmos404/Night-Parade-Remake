﻿using UnityEngine;

public class Forest_Area1And2 : MonoBehaviour
{
    public Transform player;
    public Transform tutorialAreaSpawnPoint;
    public Transform sacredAreaSpawnPoint;
    public void Start () {
        GameMaster gameMaster = FindObjectOfType<GameMaster> ();
        gameMaster.UpdateCurrentScene ();
        if (gameMaster.getPrevScene () == "Forest_Tutorial") {
            player.position = tutorialAreaSpawnPoint.position;
            player.localScale = new Vector3 (1f, 1f, 1f);
        }
        else if (gameMaster.getPrevScene() == "Forest_Sacred") {
            player.position = sacredAreaSpawnPoint.position;
            player.localScale = new Vector3 (-1f, 1f, 1f);
        }
    }
}