using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject attackRangeVizualisation;

    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;
    public float distanceToTarget;
    public float detectTarget;
    public float attackCD;
    float attackRange;

    private bool canAttack;

    void Start()
    {
        canAttack = true;
        attackRangeVizualisation.transform.localScale = new Vector3(detectTarget,.5f, detectTarget);
    }
    private void GetToPlayer()
    {
        if (distanceToTarget <= detectTarget && (distanceToTarget >= 1f))
        {
            agent.SetDestination(target.position);
        }
    }

    private void CloseToPlayer()
    {
        if(distanceToTarget <= 1f)
        {
            agent.SetDestination(transform.position);
        }
    }

    void Update()
    {
        // MOUVEMENT
        GetToPlayer();
        CloseToPlayer();
        // ATTACK

        //  OUI
        distanceToTarget = Vector3.Distance(target.position, transform.position);
    }
}