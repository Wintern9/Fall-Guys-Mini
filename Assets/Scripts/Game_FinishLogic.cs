using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_FinishLogic : MonoBehaviour
{
    public GameObject UIFinish;
    public GameObject Player;
    public GameObject Camera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIFinish.SetActive(true);
            Player.GetComponent<Player_Movement>().enabled = false;
            Camera.GetComponent<Player_CameraContoller>().enabled = false;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Game_Controller.GameOver = true;
            Game_Controller.Win = true;
        }
    }

    public void ButtonRestart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
