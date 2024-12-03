using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;  // Ссылка на джойстик
    public float moveSpeed = 5f;  // Скорость движения игрока
    private Rigidbody2D rb;  // Ссылка на Rigidbody2D компонента

    // Границы движения
    public Vector2 minBounds;
    public Vector2 maxBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Получаем Rigidbody2D
    }

    void FixedUpdate()
    {
        // Получаем значения с джойстика
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        // Нормализуем и создаём движение
        Vector2 moveInput = new Vector2(moveX, moveY).normalized;
        rb.velocity = moveInput * moveSpeed;

        // Ограничиваем движение по осям X и Y
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
