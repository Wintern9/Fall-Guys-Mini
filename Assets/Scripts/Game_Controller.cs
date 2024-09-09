using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{

    [SerializeField] private GameObject Camera;
    private Animator animatorCamera;
    private Player_CameraContoller controllerCamera;
    [SerializeField] private Animator Player_Controller;

    public GameObject UI_GameObject;

    private float _timeResult;

    void Start()
    {
        animatorCamera = Camera.GetComponent<Animator>();
        controllerCamera = Camera.GetComponent<Player_CameraContoller>();
    }

    void FixedUpdate()
    {
        if (animatorCamera.GetCurrentAnimatorStateInfo(0).IsName("Game"))
        {
            controllerCamera.enabled = true;
            animatorCamera.enabled = false;
        }

        _timeResult += Time.fixedDeltaTime;
        Debug.Log(_timeResult);
    }

    public void UI_ButtonStartDown()
    {
        StartGame();
    }

    private void StartGame()
    {
        Player_Controller.SetBool("Start", true);
        animatorCamera.SetBool("Start", true);
        UI_GameObject.SetActive(false);
    }
}
