using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_CameraContoller : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float height = 2.0f;  
    public float rotationSpeed = 5.0f;
    public float velocityCamera = 5.0f;
    public float collisionRadius = 0.5f;

    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float yMinLimit = -40f;
    private float yMaxLimit = 80f;

    private void Start()
    {
        Vector3 angles = transform.eulerAngles;
        currentX = angles.y;
        currentY = angles.x;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        currentX += Input.GetAxis("Mouse X") * rotationSpeed;
        currentY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        currentY = Mathf.Clamp(currentY, yMinLimit, yMaxLimit);

        rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 direction = new Vector3(0, height, -distance);
        Vector3 desiredPosition = target.position + rotation * direction;

        RaycastHit hit;
        if (Physics.SphereCast(target.position, collisionRadius, desiredPosition - target.position, out hit, distance))
        {
            desiredPosition = hit.point;
        }

        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * velocityCamera);

        transform.LookAt(target.position + Vector3.up * height);
    }

    Quaternion rotation;

    public Quaternion GetQuaternionCamera()
    {
        return rotation;
    }
}
