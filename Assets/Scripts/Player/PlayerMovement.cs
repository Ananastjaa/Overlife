using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;  // Ссылка на джойстик
    public float moveSpeed = 5f;  // Скорость движения игрока
    private Rigidbody2D rb;  // Ссылка на Rigidbody2D компонента

    //// Границы движения
    //public Vector2 minBounds;
    //public Vector2 maxBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Получаем Rigidbody2D
    }

    void FixedUpdate()
    {
        // Get joystick values
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        // Create a movement vector and normalize it to maintain consistent speed
        Vector2 moveInput = new Vector2(moveX, moveY);
        if (moveInput.magnitude > 1)
        {
            moveInput.Normalize(); // Ensures diagonal movement isn't faster
        }

        // Apply movement to Rigidbody
        rb.velocity = moveInput * moveSpeed;

        // Optional: Rotate the player to face the movement direction
        if (moveInput != Vector2.zero)
        {
            float angle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
