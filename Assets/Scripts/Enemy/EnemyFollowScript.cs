using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class EnemyFollowScript : MonoBehaviour {


    [SerializeField] Transform player;
    [SerializeField] Vector3 healthBarOffset;

    private Rigidbody2D enemyRB;
    private Camera myCamera;
    private Slider healthBar;

    NavMeshAgent agent;

    void Start(){

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        
        agent.updateUpAxis = false;

        enemyRB = GetComponent<Rigidbody2D>();
        myCamera = Camera.main;
        healthBar = GetComponentInChildren<Slider>();

    }

    void Update() {
        agent.SetDestination(player.position); //Sets destination, moves the enemy and calculates the path
        rotateEnemyToPlayer();
    }
    

    private void rotateEnemyToPlayer(){
        enemyRB.rotation = Mathf.Atan2(player.transform.position.y, player.transform.position.x) * Mathf.Rad2Deg; //Find the angle and rotate the enemy to the player
        healthBar.transform.rotation = myCamera.transform.rotation; //Makes the healthBar face the camera
        healthBar.transform.position = transform.position + healthBarOffset; //Makes the healthBar to be above the player on the offset value
    }
}


// Old working stuff for a simple straigthforward following
    /*//Public
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
    */