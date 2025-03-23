using UnityEngine;

public class PipeMiddle : MonoBehaviour
{
    // Increase the score by 1 when the bird crosses
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bird"))
            EventManager.IncreaseScore(1);
    }
}