using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _cameraSpeed;
    [SerializeField] private float _offsetX, _offsetY, _offsetZ;

    private Vector3 _targetPosition;

    private void Update()
    {
        _targetPosition = new Vector3(_player.transform.position.x + _offsetX, _player.transform.position.y + _offsetY, _player.transform.position.z + _offsetZ);
        transform.position = Vector3.Lerp(transform.position, _targetPosition, _cameraSpeed * Time.deltaTime);
    }
}
