using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    public Vector3 offset;   // Смещение камеры относительно игрока
    public Transform ground; // Reference to the ground object to set camera bounds

    private float minX, maxX, minY, maxY;
    private Vector3 targetPosition;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = GetComponent<Camera>();

        // Если смещение не указано, устанавливаем его как разницу между позицией камеры и игроком
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }

        SetCameraBounds();
    }

    void Update()
    {
        // Обновляем позицию камеры, следя за игроком
        if (player != null && !player.IsDestroyed()) {
            targetPosition = player.position + offset;

            // Clamp the camera position to stay within the boundaries of the ground
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

            transform.position = targetPosition;
        }
        
    }

    void SetCameraBounds()
    {
        // works if grund is rectangle!!!
        Renderer groundRenderer = ground.GetComponent<Renderer>();

        float halfHeight = mainCamera.orthographicSize;
        float halfWidth = mainCamera.aspect * halfHeight;

        minX = ground.position.x - groundRenderer.bounds.size.x / 2 + halfWidth;
        maxX = ground.position.x + groundRenderer.bounds.size.x / 2 - halfWidth;
        minY = ground.position.y - groundRenderer.bounds.size.y / 2 + halfHeight;
        maxY = ground.position.y + groundRenderer.bounds.size.y / 2 - halfHeight;
    }
}
