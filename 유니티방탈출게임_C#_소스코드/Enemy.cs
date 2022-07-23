using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class Enemy : MonoBehaviour
{
    NavMeshAgent pathfinder;
    Transform target;
    public float distance;


    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        distance = Vector3.Distance(target.position, transform.position);
        animator.SetFloat("distance", distance);
        
        if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Run"))
        {
            pathfinder.SetDestination(target.position);
            pathfinder.speed = 3.0f;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.Attack"))
        {
            pathfinder.SetDestination(target.position);
            pathfinder.speed = 0.0f;
        }

        
        else
        {
            pathfinder.SetDestination(target.position);
            pathfinder.speed = 0.0f;
        }


    }
}