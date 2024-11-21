using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarScript : MonoBehaviour{

    public Slider healthBar;
    private EnemyStats enemyStats;


    // Start is called before the first frame update
    void Start(){
        //Init scripts
        enemyStats = GetComponent<EnemyStats>();

        //Init game
        enemyStats.enemyCurrentHP = enemyStats.enemyMaxHP;  //Temporal fix so that the slider would be filled from the begining
        updateEnemyHealthBar();

        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void updateEnemyHealthBar() {
        healthBar.value = enemyStats.enemyCurrentHP / enemyStats.enemyMaxHP;
    }
}
