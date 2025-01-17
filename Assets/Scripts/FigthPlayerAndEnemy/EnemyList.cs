using System.Collections.Generic;
using UnityEngine;

public static class EnemyList
{
    public static List<Transform> Enemies = new List<Transform>();
    public static Vector3 NearestEnemy { get { return _nearestEnemy; } }

    private static double _minDist, _dist;
    private static Vector3 _nearestEnemy;

    public static void GetNearestEnemiposition(Vector3 playerPosition)
    {
        _minDist = 100000000000;
        foreach (var enemy in Enemies)
        {
            _dist = Vector3.Distance(enemy.position, playerPosition);
            if (_dist < _minDist)
            {
                _nearestEnemy = enemy.position;
                _minDist = _dist;
            }
        }
    }
}
