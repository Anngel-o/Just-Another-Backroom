using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float forceJump = 250f, speed = 50f;
    private Rigidbody rb;
    private PlayerInput playerInput;
    private Vector2 input;
    private Animator animator;
    public Light light;

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
        animator.SetBool("walk", isWalking);
    }

    private void FixedUpdate()
    {
        //rb.AddForce(new Vector3(input.x, 0f, input.y) * speed);
        //rb.linearVelocity = new Vector3(input.x * speed, 0f, input.y) * speed;
        Vector3 move = new Vector3(input.x, 0f, input.y);
        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);

    }

    public void Light(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            light.enabled = !light.enabled;
        }
    }

}
