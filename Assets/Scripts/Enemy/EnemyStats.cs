using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour{
    private GameObject player;
    private EnemyFollowScript enemyFollowScript;

    public float enemyMaxHP = 10;
    public float enemyCurrentHP;
    public float distanceToGetHit = 2.5f;


    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        enemyFollowScript = GetComponent<EnemyFollowScript>();
    }

    // Update is called once per frame
    void Update(){
        
    }

    public bool enemyGotCloseToThePlayerFoo(){
        return enemyFollowScript.distanceToThePlayerFoo() <= distanceToGetHit;
    }
}
