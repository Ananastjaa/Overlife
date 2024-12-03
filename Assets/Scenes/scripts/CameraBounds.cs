using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform player; // Игрок или объект, за которым камера будет следить
    public Vector2 minBounds; // Минимальные границы
    public Vector2 maxBounds; // Максимальные границы

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 newPosition = player.position;

        // Получаем размеры экрана в мировых координатах
        float halfWidth = cam.orthographicSize * cam.aspect;
        float halfHeight = cam.orthographicSize;

        // Ограничиваем камеру по оси X и Y
        float clampedX = Mathf.Clamp(newPosition.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(newPosition.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

        // Применяем ограниченную позицию
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
