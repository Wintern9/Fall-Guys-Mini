using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_StateMovement : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        MovingForward,
        MovingBackward,
        MovingRight,
        MovingLeft,
        MovingJump
    }

    private PlayerState currentState;

    public PlayerState GetPlayerState()
    {
        return currentState; 
    }

    Player_Movement PlMove;

    void Start()
    {
        currentState = PlayerState.Idle;
        PlMove = gameObject.GetComponent<Player_Movement>();
    }

    void Update()
    {
        UpdatePlayerState();
    }

    private void UpdatePlayerState()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (PlMove.GetJump())
        {
            currentState = PlayerState.MovingJump;
        }
        else if(moveVertical > 0)
        {
            currentState = PlayerState.MovingForward;
        }
        else if (moveVertical < 0)
        {
            currentState = PlayerState.MovingBackward;
        }
        else if (moveHorizontal > 0)
        {
            currentState = PlayerState.MovingRight;
        }
        else if (moveHorizontal < 0)
        {
            currentState = PlayerState.MovingLeft;
        } 
        else
        {
            currentState = PlayerState.Idle;
        }

        Debug.Log("Current State: " + currentState);
    }
}
