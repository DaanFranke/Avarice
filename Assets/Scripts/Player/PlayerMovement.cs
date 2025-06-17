using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    private Transform playerTransform;
    private InputAction sprintAction;

    public float moveSpeed;
    public float maxSpeed;
    public float sprintModifier;
    public float crouchSpeedModifier;

    private Vector3 moveDirection;

    public float jumpHeight;

    private bool grounded;
    private bool isCrouching = false;
    public bool isSprinting = false;

    public float gravityModifier;
    public float accelIncrease;
    private float accelSpeed = 1.0f;

    //Stamina costs and references
    private PlayerResources rescourcesReference;
    private bool outOfStamina;

    public float sprintStaminaDrain;
    public float jumpStaminaDrain;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        playerTransform = GetComponent<Transform>();
        rescourcesReference = GetComponentInParent<PlayerResources>();
        
        var playerInput = GetComponent<PlayerInput>();
        sprintAction = playerInput.actions["Sprint"];
    }

    public void OnMove(InputAction.CallbackContext context) 
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

        if (context.canceled) 
        { 
            moveDirection = Vector3.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context) 
    {
        if (context.performed && grounded && isCrouching == false && outOfStamina == false) 
        {
            rescourcesReference.StaminaChange(jumpStaminaDrain);

            rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
        }
    }

    public void OnSprint(InputAction.CallbackContext context) 
    { 
        if (context.performed && grounded && isCrouching == false && outOfStamina == false) 
        {
            isSprinting = true;
            moveSpeed *= sprintModifier;
            maxSpeed *= sprintModifier;
        }

        if (context.canceled && isSprinting == true) 
        {
            moveSpeed /= sprintModifier;
            maxSpeed /= sprintModifier;
            isSprinting = false;
        }
    }

    public void OnCrouch(InputAction.CallbackContext context) 
    { 
        if (context.performed && isSprinting == false)
        {
            isCrouching = true;

            playerTransform.localScale = new Vector3(1, 0.5f, 1);

            moveSpeed *= crouchSpeedModifier;
            maxSpeed *= crouchSpeedModifier;
        }

        if (context.canceled && isCrouching == true) 
        {
            playerTransform.localScale = new Vector3(1, 1, 1);

            moveSpeed /= crouchSpeedModifier;
            maxSpeed /= crouchSpeedModifier;

            isCrouching = false;
        }
    }

    private void Update()
    {
        //Check OoS
        outOfStamina = rescourcesReference.outOfStamina;

        //Sprint stamina drain
        if (isSprinting == true) 
        {
            outOfStamina = rescourcesReference.StaminaChange(sprintStaminaDrain * Time.deltaTime);
            
            if (outOfStamina == true) 
            {
                sprintAction.Disable();
                sprintAction.Enable();
            }
        }
    }

    private void FixedUpdate()
    {
        GroundCheck();

        if (moveDirection != Vector3.zero)
        {
            rb.AddRelativeForce(moveDirection * moveSpeed, ForceMode.Impulse);
        }
        
        if (rb.linearVelocity.magnitude > maxSpeed) 
        { 
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

        Gravity();
    }

    private void Gravity() 
    {        
        if (grounded == false) 
        {
            rb.AddForce(Vector3.down * gravityModifier * accelSpeed, ForceMode.Force);
            accelSpeed += accelIncrease;
        }
        
        if (grounded) 
        {
            accelSpeed = 1.0f;
        }
    }

    private void GroundCheck() 
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerTransform.localScale.y + 0.2f);
    }
}
