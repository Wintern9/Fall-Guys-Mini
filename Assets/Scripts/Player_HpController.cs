using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_HpController : MonoBehaviour
{
    private int _playerHP = 100;
    public GameObject UIDeath;

    public Camera camera;

    public int PlayerHP
    {
        get { return _playerHP; }
        set
        {
            if (_playerHP != value)
            {
                _playerHP = value;
                OnTextChanged();

                if (_playerHP <= 0)
                {
                    PlayerDeath();
                }
            }
        }
    }

    public TextMeshProUGUI UIHPText;

    void Start()
    {
        UIHPText.text = $"HP {PlayerHP}";
    }

    void OnTextChanged()
    {
        UIHPText.text = $"HP {PlayerHP}";
    }

    void PlayerDeath()
    {
        UIDeath.SetActive(true);
        gameObject.GetComponent<Player_Movement>().enabled = false;
        camera.GetComponent<Player_CameraContoller>().enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        Game_Controller.GameOver = true;
    }
}
