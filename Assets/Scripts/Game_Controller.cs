using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Game_Controller : MonoBehaviour
{

    [SerializeField] private GameObject Camera;
    private Animator animatorCamera;
    private Player_CameraContoller controllerCamera;
    [SerializeField] private Animator Player_Controller;

    public GameObject UI_GameObject;

    private float _timeResult;
    static public float BestResult;

    public TextMeshProUGUI TextMeshProUGUI;
    public TextMeshProUGUI TextMeshProUGUIBest;

    static public bool GameOver = false;
    static public bool Win = false;

    void Start()
    {
        GameOver = true;
        Win = false;
        animatorCamera = Camera.GetComponent<Animator>();
        controllerCamera = Camera.GetComponent<Player_CameraContoller>();

        TextMeshProUGUIBest.text = ConvertFloatToTime(BestResult);
    }

    void FixedUpdate()
    {
        if (animatorCamera.GetCurrentAnimatorStateInfo(0).IsName("Game"))
        {
            controllerCamera.enabled = true;
            animatorCamera.enabled = false;
        }

        if (!GameOver)
        {
            _timeResult += Time.fixedDeltaTime;

            TextMeshProUGUI.text = ConvertFloatToTime(_timeResult);
        }

        if (_timeResult < BestResult && Win)
        {
            BestResult = _timeResult;
        }

        Debug.Log(_timeResult);
    }

    string ConvertFloatToTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60); // Получаем количество минут
        int seconds = Mathf.FloorToInt(time % 60); // Получаем оставшиеся секунды

        // Возвращаем строку в формате "MM:SS"
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UI_ButtonStartDown()
    {
        StartGame();
    }

    private void StartGame()
    {

        GameOver = false;
        Player_Controller.SetBool("Start", true);
        animatorCamera.SetBool("Start", true);
        UI_GameObject.SetActive(false);

        Player_Controller.gameObject.GetComponent<Player_Movement>().enabled = true;

    }
}
