using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFollowScript : MonoBehaviour{
    //Public
    public float followSpeed = 2.0f;
    public Slider healthBar;
    
    public Vector3 healthBarTargetOffset;

    //Private
    private GameObject player;
    private Rigidbody2D enemyRB;
    private EnemyStats enemyStats;
    private Camera myCamera;
    private float angleToThePlayer;
    private Vector3 directionToThePlayer;

    //Start is called before the first frame update
    void Start(){
        //init vars
        myCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
        enemyRB = GetComponent<Rigidbody2D>();
        enemyStats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update(){
        directEnemyToPlayer();
        enemyGo();

        
    }

    private void directEnemyToPlayer() {
        directionToThePlayer = player.transform.position - transform.position; //Direction of the player for the enemy
        directionToThePlayer.Normalize();
        angleToThePlayer = Mathf.Atan2(directionToThePlayer.y, directionToThePlayer.x) * Mathf.Rad2Deg; //Find the angle to rotate the enemy to the player        
    }

    private void enemyGo (){
        if (!enemyStats.enemyGotCloseToThePlayerFoo())
        { //Enemy is Far from the player
            enemyRB.MovePosition(transform.position + (directionToThePlayer * followSpeed * Time.deltaTime)); //Move the enemy to the player
            enemyRB.rotation = angleToThePlayer; //Rotate the enemy to the player
        }
        healthBar.transform.rotation = myCamera.transform.rotation;
        healthBar.transform.position = transform.position + healthBarTargetOffset;
    }
}
