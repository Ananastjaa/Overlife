using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieScript : MonoBehaviour{

    public GameObject enemy;
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
        enemyManagerScript.currentEnemyCount--;
        if (enemyManagerScript.currentEnemyCount < 0)
        {
            enemyManagerScript.currentEnemyCount = 0; // Safety check
        }
        Destroy(gameObject);
    }
}
