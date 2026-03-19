using UnityEngine;

public class EscuchaColisiones : MonoBehaviour
{
    public bool isJumping {get; private set;} = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        isJumping = false;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isJumping = true;
    }
}