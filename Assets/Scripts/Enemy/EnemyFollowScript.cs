using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using NavMeshPlus.Extensions;


public class EnemyFollowScript : MonoBehaviour {


    [SerializeField] Transform player;
    [SerializeField] Vector3 healthBarOffset;
    public float rotationSpeed = 5f; // Controls how quickly the enemy rotates

    private Rigidbody2D enemyRB;
    private Camera myCamera;
    private Slider healthBar;

    NavMeshAgent agent;
    private RotateAgentSmoothly rotateAgentSmoothly;

    


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
        //Enemy Rotation
        Vector3 velocity = agent.desiredVelocity; //Getting the position of the enemies path
        float targetAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg; //Find the angle to rotate the enemy to the path
        enemyRB.rotation = Mathf.LerpAngle(enemyRB.rotation, targetAngle, Time.deltaTime * rotationSpeed); //Make the angle smooth and rotate the player.

        //Healthbar rotation
        healthBar.transform.rotation = myCamera.transform.rotation; //Makes the healthBar face the camera
        healthBar.transform.position = transform.position + healthBarOffset; //Makes the healthBar to be above the player on the offset value
    }
}