using UnityEngine;

public class DroppableResetArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<Droppable>(out var droppable)) return;
        droppable.ResetToStartPosition();
    }
}
