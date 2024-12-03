using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject enemy;
    private EnemyHealthBarScript healthBarScript;
    private EnemyManager enemyManagerScript;

    //init vars
    [SerializeField] float enemyZSpawnCoordinate = -5;
    private System.Random random;


    void Start()
    {
        //init Scripts
        healthBarScript = GetComponent<EnemyHealthBarScript>();
        enemyManagerScript = GameObject.FindGameObjectWithTag("Environment").GetComponent<EnemyManager>();


        random = new System.Random(); // Initialize the random generator
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float spawnX, spawnY;

        if (random.NextDouble() > 0.5f)
        {// Spawn on left or right

            spawnX = random.NextDouble() > 0.5 ? enemyManagerScript.CameraXMin : enemyManagerScript.CameraXMin;
            spawnY = Mathf.Lerp(enemyManagerScript.CameraYMin, enemyManagerScript.CameraYMax, (float)random.NextDouble());
        }
        else// Spawn on top or bottom
        {
            
            spawnY = random.NextDouble() > 0.5 ? enemyManagerScript.CameraYMax : enemyManagerScript.CameraYMin;
            spawnX = Mathf.Lerp(enemyManagerScript.CameraXMin, enemyManagerScript.CameraXMax, (float)random.NextDouble());
        }

        return new Vector3(spawnX, spawnY, enemyZSpawnCoordinate);
    }

    public void SpawnEnemy()
    {
        enemyManagerScript.CurrentEnemyCounter++;
        
        Instantiate(enemy, GetRandomSpawnPosition(), Quaternion.identity); // Instantiate the enemy at the calculated position
        
    }



}