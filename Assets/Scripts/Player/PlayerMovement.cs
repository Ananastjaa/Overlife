using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed = 5f; 
    private Rigidbody2D rb;
    private Vector3 _nearestEnemy;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    void FixedUpdate()
    {
        //rotation
        EnemyList.GetNearestEnemiposition(transform.position);
        _nearestEnemy = EnemyList.NearestEnemy;
        Vector3 direction = transform.position - _nearestEnemy;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Get joystick values
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        Vector2 moveInput = new Vector2(moveX, moveY);
        if (moveInput.magnitude > 1)
        {
            moveInput.Normalize(); // Ensures diagonal movement isn't faster
        }

        // Apply movement to Rigidbody
        rb.velocity = moveInput * moveSpeed;
    }
}
