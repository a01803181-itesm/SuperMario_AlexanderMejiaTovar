using UnityEngine;
using UnityEngine.InputSystem;

public class ManejaAnimacion : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    private EscuchaColisiones escuchaColisiones;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        escuchaColisiones = GetComponentInChildren<EscuchaColisiones>();
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = rigidBody2D.linearVelocityX < -1;
        animator.SetBool("isWalking", rigidBody2D.linearVelocityX < -1 || rigidBody2D.linearVelocityX > 1);
        if (escuchaColisiones.isJumping)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
}
