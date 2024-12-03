using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;  // ������ �� ��������
    public float moveSpeed = 5f;  // �������� �������� ������
    private Rigidbody2D rb;  // ������ �� Rigidbody2D ����������

    // ������� ��������
    public Vector2 minBounds;
    public Vector2 maxBounds;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // �������� Rigidbody2D
    }

    void FixedUpdate()
    {
        // �������� �������� � ���������
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        // ����������� � ������ ��������
        Vector2 moveInput = new Vector2(moveX, moveY).normalized;
        rb.velocity = moveInput * moveSpeed;

        // ������������ �������� �� ���� X � Y
        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
