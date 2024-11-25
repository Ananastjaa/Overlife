using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieScript : MonoBehaviour{

    public GameObject Enemy;
    private EnemyManager enemyManagerScript;

    // Start is called before the first frame update
    void Start(){
        enemyManagerScript = GameObject.FindGameObjectWithTag("Environment").GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enemyDie() {
        enemyManagerScript.CurrentEnemyCounter--;
        if (enemyManagerScript.CurrentEnemyCounter < 0)
        {
            enemyManagerScript.CurrentEnemyCounter = 0; // Safety check
        }
        Destroy(gameObject);
        enemyManagerScript.StartCoroutine(enemyManagerScript.EnemySpawnRoutine());
    }
}
