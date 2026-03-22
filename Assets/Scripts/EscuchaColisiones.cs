// Author: Alexander Mejia Tovar (A01803181)

using UnityEngine;

public class EscuchaColisiones : MonoBehaviour
{
    public bool isJumping {get; private set;} = false;

    // Detects when entering a trigger collider and sets isJumping to false (e.g., landing on ground).
    void OnTriggerEnter2D(Collider2D collision)
    {
        isJumping = false;
    }

    // Detects when exiting a trigger collider and sets isJumping to true (e.g., leaving the ground).
    void OnTriggerExit2D(Collider2D collision)
    {
        isJumping = true;
    }
}