// Author: Alexander Mejia Tovar (A01803181)

using UnityEngine;

public class ManejaAnimacion : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    private EscuchaColisiones escuchaColisiones;
    // Initializes animator, sprite renderer, rigidbody, and collision listener components.
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        escuchaColisiones = GetComponentInChildren<EscuchaColisiones>();
    }

    // Updates sprite flipping and animator states based on horizontal velocity and jumping status.
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
