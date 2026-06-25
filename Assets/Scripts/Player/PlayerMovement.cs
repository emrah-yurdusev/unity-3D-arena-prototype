using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float jumpForce = 7f;

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 150f;

    [Header("Camera Settings")]
    public Transform cameraTransform;
    public float rotationSpeed = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

       
        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
        MovePlayer();
    }

    private void MovePlayer()
{
    float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed;

    Vector3 cameraForward = cameraTransform.forward;
    Vector3 cameraRight = cameraTransform.right;

    cameraForward.y = 0f;
    cameraRight.y = 0f;

    cameraForward.Normalize();
    cameraRight.Normalize();

    Vector3 moveDirection = cameraForward * verticalInput + cameraRight * horizontalInput;
    moveDirection.Normalize();

    Vector3 targetVelocity = moveDirection * currentSpeed;
    targetVelocity.y = rb.velocity.y;

    rb.velocity = targetVelocity;

    Vector3 lookDirection = cameraTransform.forward;
    lookDirection.y = 0f;
    lookDirection.Normalize();

    if (lookDirection != Vector3.zero)
    {
        Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
    }
}

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    private void CheckGround()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);
    }
}