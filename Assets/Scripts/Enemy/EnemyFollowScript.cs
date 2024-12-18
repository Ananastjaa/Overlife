using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using NavMeshPlus.Extensions;
using Unity.VisualScripting;


public class EnemyFollowScript : MonoBehaviour {


    GameObject player;
    [SerializeField] Vector3 healthBarOffset;
    public float rotationSpeed = 5f; // Controls how quickly the enemy rotates

    private Rigidbody2D _enemyRB;
    private Camera _myCamera;
    private Slider _healthBar;
    private Animator _animator;
    

    public NavMeshAgent agent;
    private RotateAgentSmoothly rotateAgentSmoothly;

    


    void Start(){

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        _animator = GetComponent < Animator > ();

        _enemyRB = GetComponent<Rigidbody2D>();
        _myCamera = Camera.main;
        _healthBar = GetComponentInChildren<Slider>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        
    }
    
    private void FixedUpdate()
    {
        if (player != null && !player.IsDestroyed())
        {
            agent.SetDestination(player.transform.position); //Sets destination, moves the enemy and calculates the path
            rotateEnemyToPlayer();
            SetAnimation();
        }
    }

    private void SetAnimation() {
        bool isPlayerInTheRange = agent.stoppingDistance >= agent.remainingDistance;

        _animator.SetBool("isPlayerInTheRange", isPlayerInTheRange);
    }


    private void rotateEnemyToPlayer(){
        ////Enemy Rotation
        Vector3 velocity = agent.desiredVelocity; // Get the desired velocity

        if (velocity.sqrMagnitude > 0.01f) // If velocity is significant, use it for rotation
        {
            float targetAngle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg; // Calculate the target angle
            _enemyRB.rotation = Mathf.LerpAngle(_enemyRB.rotation, targetAngle - 90, Time.deltaTime * rotationSpeed); // Smooth rotation
        }
        else // If velocity is too small, rotate directly toward the player
        {
            Vector3 direction = (player.transform.position - transform.position).normalized; // Direction towards the player
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Use direction to calculate angle
            _enemyRB.rotation = Mathf.LerpAngle(_enemyRB.rotation, targetAngle - 90, Time.deltaTime * rotationSpeed);
        }
        

        //Healthbar rotation
        _healthBar.transform.rotation = _myCamera.transform.rotation; //Makes the healthBar face the camera
        _healthBar.transform.position = transform.position + healthBarOffset; //Makes the healthBar to be above the player on the offset value
    }

    //public float distanceToThePlayerFoo(){
    //    return agent.remainingDistance;
    //}

}