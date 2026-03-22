// Author: Alexander Mejia Tovar (A01803181)

using UnityEngine;

public class EscuchaColisionConMario : MonoBehaviour
{
    public bool isCollisioningWithMario {get; private set;} = false;

    // Detects collision with Mario and deactivates this gameObject if collided.
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Mario")
        {
            gameObject.SetActive(false);
        }
    }
}
