using UnityEngine;

public class HealthBarFollow : MonoBehaviour
{
    // !! i made this class because without this helthbar begins to rotate along with the player, what looks terrible
    
    [SerializeField] private Transform _player;  
    private Vector3 _newPosition, _offset = new Vector2(0, 1);

    void FixedUpdate()
    {
        _newPosition = _player.position + _offset;
        transform.position = _newPosition;
    }
}
