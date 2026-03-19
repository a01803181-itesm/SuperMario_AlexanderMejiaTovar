using UnityEngine;

public class EscuchaColisionConMario : MonoBehaviour
{
    public bool isCollisioningWithMario {get; private set;} = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Mario")
        {
            gameObject.SetActive(false);
        }
    }
}
