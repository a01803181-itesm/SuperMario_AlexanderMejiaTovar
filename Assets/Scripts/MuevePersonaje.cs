using UnityEngine;
using UnityEngine.Animations;
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        escuchaColisiones = GetComponentInChildren<EscuchaColisiones>();
    }

    void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();
        jumpAction.performed += jump;
    }

    public void jump(InputAction.CallbackContext context)
    {
        if (!escuchaColisiones.isJumping)
            rigidBody.linearVelocityY = velocity;
    }

    void OnDisable()
    {
        jumpAction.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = moveAction.ReadValue<Vector2>();
        rigidBody.linearVelocityX = velocity * movement.x;
    }
}
