// Author: Alexander Mejia Tovar (A01803181)

using UnityEngine;
using UnityEngine.InputSystem;

public class MuevePersonaje : MonoBehaviour
{
    [SerializeField]
    private InputAction moveAction;
    [SerializeField]
    private InputAction jumpAction;
    private Rigidbody2D rigidBody;

    private EscuchaColisiones escuchaColisiones;

    private float velocity = 5f;

    // Initializes rigidbody and collision listener components.
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        escuchaColisiones = GetComponentInChildren<EscuchaColisiones>();
    }

    // Enables input actions and subscribes to the jump event.
    void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        jumpAction.performed += jump;
    }

    // Applies upward velocity for jumping if the character is not already jumping.
    public void jump(InputAction.CallbackContext context)
    {
        if (!escuchaColisiones.isJumping)
            rigidBody.linearVelocityY = velocity;
    }

    // Disables the jump input action.
    void OnDisable()
    {
        jumpAction.Disable();
    }

    // Updates horizontal velocity based on movement input.
    void Update()
    {
        Vector2 movement = moveAction.ReadValue<Vector2>();
        rigidBody.linearVelocityX = velocity * movement.x;
    }
}
