using UnityEngine;

public class MueveGoomba : MonoBehaviour
{
    private int step_counter = 0;
    private Rigidbody2D rb;
    private bool flipGoomba = false;
    private SpriteRenderer spriteRenderer;
    private EscuchaColisionesGoomba escuchaColisionesGoomba;
    private float displacement = -3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        escuchaColisionesGoomba = GetComponentInChildren<EscuchaColisionesGoomba>();
    }

    // Update is called once per frame
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
