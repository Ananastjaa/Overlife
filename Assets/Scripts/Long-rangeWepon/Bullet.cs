using UnityEngine;

public class Bullet : MonoBehaviour
{
    // later here can be bullet sprite
    private float _demage = 1f, _speed = 5f;
    // private Vector3 _target;     use target AND in Fized update calculate direction to chase te terget

    private Vector3 _direction = new Vector3(0, 1, 0);

    public void SetBullet(float demage, float speed, Vector3 _target)
    {
        _demage = demage;
        _speed = speed;
    }

    private void FixedUpdate()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
        if (transform.position.x > 40 || transform.position.y > 40 || transform.position.x < -40 || transform.position.y < -40) Destroy(gameObject); // must be overwrite, couse this is tupid idea
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyFight>())
        {
            collision.gameObject.GetComponent<EnemyFight>().GetDemage(_demage);
        }
        Destroy(gameObject);
    }
}
