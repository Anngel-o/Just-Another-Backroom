using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 3f, runSpeed = 5.5f;
    private Rigidbody rb;
    private PlayerInput playerInput;
    private Vector2 input;
    private Animator animator;
    public Light light;
    private bool isRunning;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        light.enabled = false;
    }

    private void Update()
    {
        input = playerInput.actions["Walk"].ReadValue<Vector2>();
        bool isWalking = input.sqrMagnitude > 0.01f;
        bool runPressed = playerInput.actions["Run"].IsPressed();

        isRunning = isWalking && runPressed;

        animator.SetBool("walk", isWalking);
        animator.SetBool("run", isRunning);
    }

    private void FixedUpdate()
    {
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 moveDirection = transform.forward * input.y + transform.right * input.x;
        rb.linearVelocity = new Vector3(moveDirection.x * currentSpeed, rb.linearVelocity.y, moveDirection.z * currentSpeed);
    }

    public void Light(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            light.enabled = !light.enabled;
        }
    }

}
