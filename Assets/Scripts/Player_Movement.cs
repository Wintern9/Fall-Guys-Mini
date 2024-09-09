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

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
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
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);  // Плавный поворот
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
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * JumpForce);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }

    public bool GetGround()
    {
        return _isGrounded;
    }
}
