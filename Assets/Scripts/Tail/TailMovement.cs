using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TailMovement : NetworkBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] TailNetwork tail;


    // Update is called once per frame
    void Update()
    {
        agent.speed = tail.Owner.Speed;
        agent.SetDestination(tail.Target.transform.position);
        //tail.Target.transform.position
    }

    private void Start()
    {
        transform.position = tail.Target.transform.position;
    }
}
