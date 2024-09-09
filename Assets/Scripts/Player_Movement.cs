using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player_Movement : MonoBehaviour
{
    public float Speed = 5f;
    public float JumpForce = 300f;
    private bool _isGrounded;
    private Rigidbody _rb;

    public Transform cameraTransform;
    CapsuleCollider capsuleCollider;

    bool _jump = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        CheckGround();
        JumpLogic();
        MovementLogic();
    }

    private void PlayerRotationAtCamera(Vector3 movementDirection)
    {
        if (movementDirection.magnitude > 0.1f)
        {
            Vector3 cameraForward = cameraTransform.forward;
            cameraForward.y = 0f;
            cameraForward.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);
        }
    }

    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = cameraTransform.TransformDirection(movement);
        movement.y = 0.0f;

        transform.Translate(movement * Speed * Time.fixedDeltaTime, Space.World);

        PlayerRotationAtCamera(movement);
    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded && !_jump)
            {
                _rb.AddForce(Vector3.up * JumpForce);
                _jump = true;
            }
        }
    }

    private void CheckGround()
    {
        float rayDistance = capsuleCollider.bounds.extents.y + 0.1f;
        Vector3 rayOrigin = transform.position;

        Ray ray = new Ray(rayOrigin, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
        }
        else
        {
            _isGrounded = false;
        }
    }

    public bool GetJump()
    {
        return _jump;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            _jump = false;
    }
}
