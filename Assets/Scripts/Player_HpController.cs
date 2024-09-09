using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player_HpController : MonoBehaviour
{
    private int _playerHP = 100;

    public int PlayerHP
    {
        get { return _playerHP; }
        set
        {
            if (_playerHP != value)
            {
                _playerHP = value;
                OnTextChanged();  // „B„„x„„r„p„u„} „}„u„„„€„t „„‚„y „y„x„}„u„~„u„~„y„y „x„~„p„‰„u„~„y„‘

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
        Debug.Log("Death");
    }
}
