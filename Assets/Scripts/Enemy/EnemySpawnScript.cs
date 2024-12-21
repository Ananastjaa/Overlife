using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnScript : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    private EnemyManager _enemyManagerScript;
    private EnvironmentManager _environmentManager;

    //init vars
    //[SerializeField] float enemyZSpawnCoordinate = -5; //For debug purposes only, so the enemy would be insight of the camera and not below ground or other stuff
    public float spawnPadding = 1.0f;
    //private System.Random random;


    void Start()
    {
        //init Scripts
        _enemyManagerScript = GameObject.FindGameObjectWithTag("Environment").GetComponent<EnemyManager>();
        _environmentManager = GameObject.FindGameObjectWithTag("Environment").GetComponent<EnvironmentManager>();
    }

    private Vector3 GetRandomSpawnPosition(){
        float[] bounds = _environmentManager.CalculateCameraBounds();
        float leftBound = bounds[0];
        float rightBound = bounds[2];
        float topBound = bounds[1];
        float bottomBound = bounds[3];
        switch (Random.Range(0, 4)) // Randomly choose one of the four sides
        {
            case 0: // Top
                return new Vector3(Random.Range(leftBound, rightBound), topBound, 0);
            case 1: // Bottom
                return new Vector3(Random.Range(leftBound, rightBound), bottomBound, 0);

            case 2: // Left
                return new Vector3(leftBound, Random.Range(bottomBound, topBound), 0);

            case 3: // Right
                return new Vector3(rightBound, Random.Range(bottomBound, topBound), 0);

            default:
                // Fallback (shouldn't happen in this context)
                Debug.Log("EnemySpawnScript in GetRandomSpawnPosition() switch returned less than 0 or more than 3");
                return Vector3.zero;
        }
    }

    public void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            _enemyManagerScript.CurrentEnemyCounter++;

            Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity); // Instantiate the enemy at the calculated position
        }
        else {
            Debug.Log("enemyPrefab==null");
        }
        
        
    }



}
