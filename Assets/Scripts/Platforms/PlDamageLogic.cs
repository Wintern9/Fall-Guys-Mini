using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlDamageLogic : MonoBehaviour
{
    private Material materialPlatform;
    bool platfromActive = true;

    Player_HpController player_HpController;

    GameObject player;
    Collider colliderPlatform;

    void Start()
    {
        materialPlatform = new Material(Shader.Find("Standard"));
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        materialPlatform.color = Color.white;
        meshRenderer.material = materialPlatform;
        player_HpController = FindFirstObjectByType<Player_HpController>();

        player = GameObject.FindGameObjectWithTag("Player");
        colliderPlatform = gameObject.GetComponent<Collider>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && platfromActive)
        {
            Invoke("PlayerDamage", 1f);
            materialPlatform.color = Color.red + Color.yellow;
            platfromActive = false;
        }
    }

    private void PlayerDamage()
    {
        Invoke("PlatformColorRestart", 1f);
        materialPlatform.color = Color.red;

        if (_playerCollision == true)
        {
            player_HpController.PlayerHP -= 100;
            
        }
    }

    bool _playerCollision = false ;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
            _playerCollision = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            _playerCollision = false;
    }

    private void PlatformColorRestart()
    {
        Invoke("PlatformActiveRestart", 4f);
        materialPlatform.color = Color.white;
    }

    private void PlatformActiveRestart()
    {
        platfromActive = true;
    }
}
