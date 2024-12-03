using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    public Vector2 minBounds; // ����������� ������� (����� ������ �����)
    public Vector2 maxBounds; // ������������ ������� (������ ������� �����)

    void Update()
    {
        // �������� ������� ������� ������
        Vector3 currentPosition = transform.position;

        // ������������ �������� �� ���� X � Y
        float clampedX = Mathf.Clamp(currentPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(currentPosition.y, minBounds.y, maxBounds.y);

        // ��������� ������������ �������� �������
        transform.position = new Vector3(clampedX, clampedY, currentPosition.z);
    }
}
