using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemySpawnScript enemySpawnScript;
    [Tooltip("How many enemies should be on the map")]
    [SerializeField] private int _enemyMaxOnMap = 5; // Max enemies allowed on the map
    [Tooltip("Scenods between new enemy spawn")]
    [SerializeField] private float _spawnRate = 3f; // Time in seconds between spawns
    [Tooltip("Current active enemies on the map")]
    public int CurrentEnemyCounter = 0;
    [SerializeField] private bool _isEnemySpawningEnabled = true; // Controls if spawning is allowed
    [HideInInspector] public float CameraXMin, CameraXMax, CameraYMin, CameraYMax;
    private bool _isEnemySpawningCoroutineRunning = false; // Tracks if the enemy spawning coroutine is currently active

    // Start is called before the first frame update
    void Start()
    {
        // Precompute camera bounds once at the start
        CalculateCameraBounds();

        enemySpawnScript = GetComponent<EnemySpawnScript>();

        StartCoroutine(EnemySpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void CalculateCameraBounds()
    {

        Camera mainCamera = Camera.main;

        // Get screen size in world units
        float screenHeight = 2f * mainCamera.orthographicSize;
        float screenWidth = screenHeight * mainCamera.aspect;

        // Calculate spawn distance beyond camera bounds
        float spawnBuffer = 2f; // Distance outside the camera view
        Vector3 cameraPosition = mainCamera.transform.position; // Camera's position

        CameraXMin = cameraPosition.x - screenWidth / 2 - spawnBuffer;
        CameraXMax = cameraPosition.x + screenWidth / 2 + spawnBuffer;
        CameraYMin = cameraPosition.y - screenHeight / 2 - spawnBuffer;
        CameraYMax = cameraPosition.y + screenHeight / 2 + spawnBuffer;
    }



    public IEnumerator EnemySpawnRoutine()
    {
        if (_isEnemySpawningCoroutineRunning) yield break; // Exit if already running

        _isEnemySpawningCoroutineRunning = true;

        try
        {
            while (_isEnemySpawningEnabled && CurrentEnemyCounter < _enemyMaxOnMap)
            {
                
                    yield return new WaitForSeconds(_spawnRate); // Wait for _spawnRate seconds

                    enemySpawnScript.SpawnEnemy(); // Spawn the enemy
                               
            }
        }
        finally
        {
            _isEnemySpawningCoroutineRunning = false; // Ensure flag resets even on interruptions
        }
    }

}
