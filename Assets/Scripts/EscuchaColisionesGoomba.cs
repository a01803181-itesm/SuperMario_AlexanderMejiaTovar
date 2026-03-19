using UnityEngine;

public class EscuchaColisionesGoomba : MonoBehaviour
{
    public bool isTriggeredByScreenWall {get; private set;} = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggeredByScreenWall = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        isTriggeredByScreenWall = false;
    }
}
