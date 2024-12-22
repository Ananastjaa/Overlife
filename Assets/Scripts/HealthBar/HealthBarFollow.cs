using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    // !! i made this class because without this helthbar begins to rotate along with the player, which looks terrible
    
    [SerializeField] private Transform _player;  
    private Vector3 _offset = new Vector2(0, 1);

    void FixedUpdate()
    {
        Vector3 newPosition = _player.position + _offset;
        transform.position = newPosition;
    }
}
