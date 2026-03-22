// Author: Alexander Mejia Tovar (A01803181)

using UnityEngine;

public class MueveGoomba : MonoBehaviour
{
    private int step_counter = 0;
    private Rigidbody2D rb;
    private bool flipGoomba = false;
    private SpriteRenderer spriteRenderer;
    private EscuchaColisionesGoomba escuchaColisionesGoomba;
    private float displacement = -3f;

    // Initializes rigidbody, sprite renderer, and collision listener components.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        escuchaColisionesGoomba = GetComponentInChildren<EscuchaColisionesGoomba>();
    }

    // Updates Goomba movement, sprite flipping, and direction reversal on wall collision.
    void Update()
    {
        if (step_counter < 180)
            ++step_counter;
        else
        {
            step_counter = 0;
            flipGoomba = !flipGoomba;
            spriteRenderer.flipX = flipGoomba;
        }
        if (escuchaColisionesGoomba.isTriggeredByScreenWall)
        {
            displacement *= -1;
        }
        rb.linearVelocityX = displacement;
    }
}
