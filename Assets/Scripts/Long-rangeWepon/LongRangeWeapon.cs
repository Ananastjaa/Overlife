using UnityEngine;

public class LongRangeWeapon : MonoBehaviour
{
    // later there will be reload speed and possibly range

    [SerializeField] private GameObject _bulletPrephab;

    [SerializeField] private float _demage = 2f, _bulletSpeed  = 10f;
    private string _longRangeWeponID;

    public void OnFire(Vector3 playerPos)
    {
        GameObject bulletObject = Instantiate(_bulletPrephab, transform.position, transform.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetBullet(_demage, _bulletSpeed, EnemyList.NearestEnemy);
    }
}
