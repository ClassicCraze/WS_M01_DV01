using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour 
 {
      // 1
     public Transform player;
     public Transform patrolRoute;
     public List<Transform> locations;
 
     // 2
     private int locationIndex = 0;
 
     // 3
     private NavMeshAgent agent;

    private int _lives = 3;
     public int EnemyLives 
     {
         // 2
         get { return _lives; }
 
         // 3
         private set 
         {
             _lives = value;
 
             // 4
             if (_lives <= 0)
             {
                 Destroy(this.gameObject);
                 Debug.Log("Enemy down.");
             }
         }
     }
 
     void Start()
     {
         // 4
         agent = GetComponent<NavMeshAgent>();

         // 2
         player = GameObject.Find("Player").transform;

         InitializePatrolRoute();
 
         // 5
         MoveToNextPatrolLocation();
     }
     void Update()
     {
         // 1
         if(agent.remainingDistance < 0.2f && !agent.pathPending)
         {
             // 2
             MoveToNextPatrolLocation();
         }
     }

           // 4
     void InitializePatrolRoute()
     {
         // 5
         foreach(Transform child in patrolRoute)
         {
             // 6
             locations.Add(child);
         }
     }
        void MoveToNextPatrolLocation()
     {
         // 3
         if (locations.Count == 0)
             return;
         
         agent.destination = locations[locationIndex].position;
 
         // 4
         locationIndex = (locationIndex + 1) % locations.Count;
     }
     // 1
     void OnTriggerEnter(Collider other)
     {
         //2 
         if(other.name == "Player")
         {
            // 3
             agent.destination = player.position;
             Debug.Log("Player detected - attack!");
         }
     }
 
     // 3
     void OnTriggerExit(Collider other)
     {
         // 4
         if(other.name == "Player")
         {
             Debug.Log("Player out of range, resume patrol");
         }
     }

     void OnCollisionEnter(Collision collision)
     {
         // 5
         if(collision.gameObject.name == "Bullet(Clone)")
         {
             // 6
             EnemyLives -= 1;
             Debug.Log("Critical hit!");
         }
     }
 }
 