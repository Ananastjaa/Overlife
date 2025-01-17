using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // later here can be bullet sprite
    private float _demage = 1f, _speed = 1f;
    private Vector3 _target;


    public void SetBullet(float demage, float speed, Vector3 target)
    {
        _demage = demage;
        _speed = speed;
        _target = target;
    }

    private void FixedUpdate()
    {
        if (transform.position == _target) Destroy(gameObject);
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyFight>()) collision.GetComponent<EnemyFight>().GetDemage(_demage);
        if (collision.tag != "Player") Destroy(gameObject);
    }
}
