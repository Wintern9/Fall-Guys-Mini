using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_DeathCollider : MonoBehaviour
{
    public Player_CameraContoller plCameraController;
    public GameObject Player;
    public GameObject UIDeath;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            plCameraController.enabled = false;
            Player.GetComponent<Player_Movement>().enabled = false;
            UIDeath.SetActive(true);
            Player.GetComponent <Player_HpController>().PlayerHP = 0;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            Game_Controller.GameOver = true;
        }
    }
}
