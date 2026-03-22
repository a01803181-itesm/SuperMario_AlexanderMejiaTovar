// Author: Alexander Mejia Tovar (A01803181)

using UnityEngine;

public class EscuchaColisionesGoomba : MonoBehaviour
{
    public bool isTriggeredByScreenWall {get; private set;} = false;

    // Detects when this object's collider starts overlapping with a trigger collider (e.g., screen wall) and sets isTriggeredByScreenWall to true.
    void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggeredByScreenWall = true;
    }
    // Detects when the trigger collision ends and sets isTriggeredByScreenWall to false.
    void OnTriggerExit2D(Collider2D collision)
    {
        isTriggeredByScreenWall = false;
    }
}
