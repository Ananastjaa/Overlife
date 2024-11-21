using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour{
    private GameObject player;

    public float enemyMaxHP = 10;
    public float enemyCurrentHP;
    public float distanceToGetHit = 1.5f;


    // Start is called before the first frame update
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update(){
        
    }

    public bool enemyGotCloseToThePlayerFoo(){
        return distanceToThePlayerFoo() <= distanceToGetHit;
    }

    public float distanceToThePlayerFoo(){
        return Vector2.Distance(transform.position, player.transform.position);
    }
}
