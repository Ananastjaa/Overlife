using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    private float _moveSpeed = 5f, _angle, _moveX, _moveY, _smoothaAngle, _rottionSpeed; 
    private Rigidbody2D rb;
    private Vector3 _nearestEnemy, _direction;
    private Vector2 _moveInput;
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
        _smoothaAngle = Mathf.SmoothDampAngle(transform.eulerAngles.z, _angle, ref _rottionSpeed, 0.1f);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, _smoothaAngle));

        // Get joystick values
        _moveX = joystick.Horizontal;
        _moveY = joystick.Vertical;

        _moveInput = new Vector2(_moveX, _moveY);
        if (_moveInput.magnitude > 1)
        {
            _moveInput.Normalize(); // Ensures diagonal movement isn't faster
        }

        // Apply movement to Rigidbody
        rb.velocity = _moveInput * _moveSpeed;
    }
}
