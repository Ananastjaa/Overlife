using NavMeshPlus.Components;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour{


    private EnemySpawnScript _enemySpawnScript;
    private Camera _cam; // Get the main camera
    //private GameObject _wall;   -  in my to do list to create _wall at level restart
    


    // Start is called before the first frame update
    void Start()
    {
        _enemySpawnScript = GetComponent<EnemySpawnScript>();
        _cam = Camera.main;
        //_wall = GetComponent<GameObject>(); -  in my to do list to create _wall at level restart

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float[] CalculateCameraBounds()
    {
        float camHeight = _cam.orthographicSize * 2; // Height of the visible area
        float camWidth = camHeight * _cam.aspect;    // Width of the visible area

        Vector3 camPosition = _cam.transform.position;

        // Bounds of the visible area
        float leftBound = camPosition.x - camWidth / 2 + _enemySpawnScript.spawnPadding;
        float rightBound = camPosition.x + camWidth / 2 + _enemySpawnScript.spawnPadding;
        float topBound = camPosition.y + camHeight / 2 + _enemySpawnScript.spawnPadding;
        float bottomBound = camPosition.y - camHeight / 2 + _enemySpawnScript.spawnPadding;

        // Return bounds as an array
        return new float[] { leftBound, topBound, rightBound, bottomBound };
    }

}
