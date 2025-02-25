using UnityEngine;

public class LongRangeWeapon : MonoBehaviour
{
    // later there will be reload speed and possibly range

    [SerializeField] private GameObject _bulletPrephab;
    [SerializeField] private float _bulletSpeed  = 12f;

    public void OnFire(Vector3 playerPos)
    {
        GameObject bulletObject = Instantiate(_bulletPrephab, transform.position, transform.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.SetBullet(Weapons.SelectedLRWeapon.WeaponCurrentData.Demage, _bulletSpeed, EnemyList.NearestEnemy);
    }
}
