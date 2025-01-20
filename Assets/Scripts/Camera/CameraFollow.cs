using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _ground; // Reference to the ground object to set camera bounds

    private float _minX, _maxX, _minY, _maxY, _halfHeight, _halfWidth;
    private Vector3 _targetPosition;
    private Camera _mainCamera;
    private Renderer _groundRenderer;

    void Start()
    {
        _mainCamera = GetComponent<Camera>();

        if (_offset == Vector3.zero)
        {
            _offset = transform.position - _player.position;
        }

        SetCameraBounds();
    }

    void Update()
    {
        if (_player != null && !_player.IsDestroyed()) {
            _targetPosition = _player.position + _offset;

            // Clamp the camera position to stay within the boundaries of the ground
            _targetPosition.x = Mathf.Clamp(_targetPosition.x, _minX, _maxX);
            _targetPosition.y = Mathf.Clamp(_targetPosition.y, _minY, _maxY);

            transform.position = _targetPosition;
        }
    }

    void SetCameraBounds()
    {
        // works only if grund is rectangle!!!
        _groundRenderer = _ground.GetComponent<Renderer>();

        _halfHeight = _mainCamera.orthographicSize;
        _halfWidth = _mainCamera.aspect * _halfHeight;

        _minX = _ground.position.x - _groundRenderer.bounds.size.x / 2 + _halfWidth;
        _maxX = _ground.position.x + _groundRenderer.bounds.size.x / 2 - _halfWidth;
        _minY = _ground.position.y - _groundRenderer.bounds.size.y / 2 + _halfHeight;
        _maxY = _ground.position.y + _groundRenderer.bounds.size.y / 2 - _halfHeight;
    }
}
