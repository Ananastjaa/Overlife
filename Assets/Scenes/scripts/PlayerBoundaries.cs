using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    public Vector2 minBounds; // Минимальные границы (левая нижняя точка)
    public Vector2 maxBounds; // Максимальные границы (правая верхняя точка)

    void Update()
    {
        // Получаем текущую позицию игрока
        Vector3 currentPosition = transform.position;

        // Ограничиваем движение по осям X и Y
        float clampedX = Mathf.Clamp(currentPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(currentPosition.y, minBounds.y, maxBounds.y);

        // Применяем ограниченные значения позиции
        transform.position = new Vector3(clampedX, clampedY, currentPosition.z);
    }
}
