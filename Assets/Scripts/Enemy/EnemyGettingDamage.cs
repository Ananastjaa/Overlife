using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGettingDamage : MonoBehaviour{

    private EnemyStats enemyStats;
    private EnemyDieScript enemyDieScript;
    //private EnemySpawnScript enemySpawnScript;
    private EnemyHealthBarScript enemyHealthBarScript;

    // Start is called before the first frame update
    void Start(){

        //init scripts
        enemyStats = GetComponent<EnemyStats>();
        enemyDieScript = GetComponent<EnemyDieScript>();
        //enemySpawnScript = GetComponent<EnemySpawnScript>();
        enemyHealthBarScript = GetComponent<EnemyHealthBarScript>();
    }

    // Update is called once per frame
    void Update(){
        if (enemyStats.enemyGotCloseToThePlayerFoo()){
            enemyGettingDamage();
        }
    }


    private void enemyGettingDamage(){
        if (enemyStats.enemyCurrentHP > 0){
            enemyStats.enemyCurrentHP -= Time.deltaTime;
            enemyHealthBarScript.updateEnemyHealthBar();
        }
        else{
            //enemySpawnScript.SpawnEnemy();
            enemyDieScript.EnemyDie();
        }
    }

}
