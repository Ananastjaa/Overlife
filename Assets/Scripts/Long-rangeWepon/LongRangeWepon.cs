using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LongRangeWepon : MonoBehaviour
{
    // this is Base Class For every Long Range Wepon
    // later there will be reload speed and possibly range

    [SerializeField] private GameObject _bulletPrephab;
    public double Demage { get { return _demage; } }
    public float BulletSpeed { get { return _bulletSpeed; } }

    private float _demage = 2f, _bulletSpeed  = 10f;

    public void OnFire(Vector3 playerPos)
    {
        GameObject bulletObject = Instantiate(_bulletPrephab, transform.position, transform.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetBullet(_demage, _bulletSpeed, EnemyList.NearestEnemy);
    }

}
