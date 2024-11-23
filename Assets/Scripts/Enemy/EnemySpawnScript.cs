using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour{

    public GameObject enemy;
    private GameObject player;
    private EnemyHealthBarScript healthBarScript;

    // Start is called before the first frame update
    void Start(){
        //init Scripts
        healthBarScript = GetComponent<EnemyHealthBarScript>();

        //Init stuff
        player = GameObject.FindGameObjectWithTag("Player");


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnEnemy() {
        Instantiate(enemy, new Vector3(0, 6, player.transform.position.z), player.transform.rotation);
        healthBarScript.updateEnemyHealthBar();
    }
}
