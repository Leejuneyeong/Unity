using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EenmeyMove : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    Animator animator;
    NavMeshAgent nav;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nav.enabled)
        {
            nav.SetDestination(player.transform.position);
        }
    }
}
