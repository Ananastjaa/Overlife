using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private EnemySpawnScript _enemySpawnScript;
    [Tooltip("How many enemies should be on the map")]
    [SerializeField] private int _enemyMaxOnMap = 5; // Max enemies allowed on the map
    [Tooltip("Scenods between new enemy spawn")]
    [SerializeField] private float _spawnRate = 3f; // Time in seconds between spawns
    [Tooltip("Current active enemies on the map")]
    public int CurrentEnemyCounter = 0;
    [SerializeField] private bool _isEnemySpawningEnabled = true; // Controls if spawning is allowed
    [HideInInspector] public float CameraXMin, CameraXMax, CameraYMin, CameraYMax;
    private bool _isEnemySpawningCoroutineRunning = false; // Tracks if the enemy spawning coroutine is currently active
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        
        _enemySpawnScript = GetComponent<EnemySpawnScript>();
        _player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(EnemySpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
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

                if (_enemySpawnScript!=null && _player != null && !_player.IsDestroyed()){
                    _enemySpawnScript.SpawnEnemy(); // Spawn the enemy
                }


            }
        }
        finally
        {
            _isEnemySpawningCoroutineRunning = false; // Ensure flag resets even on interruptions
        }
    }

}
