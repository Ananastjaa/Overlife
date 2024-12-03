using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Transform player; // ����� ��� ������, �� ������� ������ ����� �������
    public Vector2 minBounds; // ����������� �������
    public Vector2 maxBounds; // ������������ �������

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 newPosition = player.position;

        // �������� ������� ������ � ������� �����������
        float halfWidth = cam.orthographicSize * cam.aspect;
        float halfHeight = cam.orthographicSize;

        // ������������ ������ �� ��� X � Y
        float clampedX = Mathf.Clamp(newPosition.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampedY = Mathf.Clamp(newPosition.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);

        // ��������� ������������ �������
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
