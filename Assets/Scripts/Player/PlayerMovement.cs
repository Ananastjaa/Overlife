using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    private float _moveSpeed = 5f, _angle, _moveX, _moveY; 
    private Rigidbody2D rb;
    private Vector3 _nearestEnemy, _direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    void FixedUpdate()
    {
        //rotation
        EnemyList.GetNearestEnemiposition(transform.position);
        _nearestEnemy = EnemyList.NearestEnemy;
        _direction = transform.position - _nearestEnemy;
        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, _angle));

        // Get joystick values
        _moveX = joystick.Horizontal;
        _moveY = joystick.Vertical;

        Vector2 moveInput = new Vector2(_moveX, _moveY);
        if (moveInput.magnitude > 1)
        {
            moveInput.Normalize(); // Ensures diagonal movement isn't faster
        }

        // Apply movement to Rigidbody
        rb.velocity = moveInput * _moveSpeed;
    }
}
