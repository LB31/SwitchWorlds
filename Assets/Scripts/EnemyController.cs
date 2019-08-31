using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    // Path finding
    public Transform goal;
    private NavMeshAgent agent;

    private Animator animator;

    private Vector3 originPos;


    private bool CrashedPlayer;
    private float t;

    private bool SpinnedWorld;

    private void Start() {
        WorldManager.Instance.WorldWasSpinned += Spinned;
        goal = GameObject.FindWithTag("Player").transform;
        originPos = transform.position;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.Play("Walk");
    }

    private void Update() {
        if (!CrashedPlayer && !SpinnedWorld) {  
                agent.destination = goal.position;        
        } else {
            t += Time.deltaTime;
        }
        if (t > 5) {
            t = 0;
            CrashedPlayer = false;
            agent.enabled = true;
            animator.Play("Walk");
        }

        // if enemy has reached his origin position
        if (!agent.pathPending && SpinnedWorld) {
            if (agent.remainingDistance <= agent.stoppingDistance) {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
                    animator.Play("Idle");
                }
            }
        }

    }

    public void Spinned() {
        animator.Play("Walk");
        SpinnedWorld = !SpinnedWorld;
        if (SpinnedWorld) {
            ReturnToSpawn();
        }
    }


    // Tracks, if angel have attacked player to stop him for some seconds
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            CrashedPlayer = true;
            agent.enabled = false;
            animator.Play("Idle");
            HealthManager.Instance.DamagePlayer(true, 10);
        }
    }

    public void ReturnToSpawn() {
        CrashedPlayer = false;
        agent.enabled = true;
        agent.destination = originPos;
        animator.Play("Walk");

    }


}
