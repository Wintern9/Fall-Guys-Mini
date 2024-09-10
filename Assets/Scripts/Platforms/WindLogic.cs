using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindLogic : MonoBehaviour
{
    private Rigidbody rbPlayer;

    public float windVelocity;

    public float RotationX = 0f;

    void Start()
    {
        rbPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        InvokeRepeating("RotateWind", 0f, 2f);
    }

    void RotateWind()
    {
        float randomYRotation = Random.Range(0f, 360f);
        Quaternion randomRotation = Quaternion.Euler(RotationX, randomYRotation, 0f);
        transform.rotation = randomRotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rbPlayer.AddForce(transform.forward * windVelocity);
        }
    }
}
