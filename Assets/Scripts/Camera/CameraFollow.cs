using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    public Vector3 offset;   // Смещение камеры относительно игрока

    void Start()
    {
        // Если смещение не указано, устанавливаем его как разницу между позицией камеры и игроком
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }
    }

    void Update()
    {
        // Обновляем позицию камеры, следя за игроком
        if (player != null && !player.IsDestroyed()) {
            transform.position = player.position + offset;
        }
        
    }
}
