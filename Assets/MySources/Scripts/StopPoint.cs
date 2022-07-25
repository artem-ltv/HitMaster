using UnityEngine;
using UnityEngine.Events;

public class StopPoint : MonoBehaviour
{
    public event UnityAction Stopping;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement playerMovement))
            playerMovement.SwitchPoseAiming(true);

        if (other.gameObject.TryGetComponent(out Player player))
            Stopping?.Invoke();
    }
}
