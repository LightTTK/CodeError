using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float ChaseDistance;
    [SerializeField] float AttackDistance;
    [SerializeField] GameObject player;
    [SerializeField] PathHolder myPathHolder;

    public MCHealthbar mCHealthbar;
    public int attack;

    bool CanPatrol; 
    bool canAttack;

    [SerializeField] Animator anim;
    Rigidbody rb;

    NavMeshAgent agent;

    private void Awake(){
        agent = GetComponent<NavMeshAgent> ();

        rb = GetComponent<Rigidbody>();
    }
    void Start() 
    {
        anim = GetComponentInChildren<Animator>();

    }

    void Update() {
        float DistanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if(DistanceToPlayer > ChaseDistance){
            //Patrol
            Patrol();
        } else if(DistanceToPlayer < ChaseDistance && DistanceToPlayer > AttackDistance){
            //Chase
            Chase();
        } else if(DistanceToPlayer < AttackDistance){
           // Attack
           Attack();
        }

    }

    void Patrol() {
        // TODO PlaceHolder
        agent.SetDestination(transform.position);
        if(!CanPatrol) StartCoroutine (PatrolThenWait ());
        anim.SetBool("Chasing", false);
    }
    IEnumerator PatrolThenWait () {
        GameObject currentPath = myPathHolder.GetPaths() [0];
        CanPatrol = true;
        //logic
        while (CanPatrol){
            while(Vector3.Distance(transform.position,currentPath.transform.position) > 1) {
                agent.SetDestination(currentPath.transform.position);
                yield return null;
            }
            for (int i = 0; i < myPathHolder.GetPaths ().Count; i++){
                if(currentPath = myPathHolder.GetPaths()[i]) {
                    int nextIndex = i += 1;
                    if(nextIndex >= myPathHolder.GetPaths().Count){
                        nextIndex = 0;
                    }
                    currentPath = myPathHolder.GetPaths()[nextIndex];
                    break;
                    
                }
                
            }
            yield return null;

        }

    }

    void Chase() {
        agent.SetDestination (player.transform.position);
        if(canAttack) StopCoroutine(AttackWithCooldown ());
        canAttack = false;

        if(CanPatrol) StopCoroutine(PatrolThenWait ());
        CanPatrol = false;

        agent.isStopped = false;
        anim.SetBool("Chasing", true);
     
    }

    void Attack() {
        if(!canAttack) StartCoroutine (AttackWithCooldown ());
    }

    IEnumerator AttackWithCooldown () {
        agent.isStopped = true;
        canAttack = true;
        while (true) {
            mCHealthbar.TakeDamage(attack);
            yield return new WaitForSeconds(1);
        }
    }
    void OnDrawGizmosSelected () {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, AttackDistance);

         Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, ChaseDistance);
    }

        public void ToggleAnimation(bool _enabled)
    {
        
    }
}
// Patrolling
// Chase
// Attack