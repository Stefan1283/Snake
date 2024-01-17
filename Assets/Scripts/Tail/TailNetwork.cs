using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class TailNetwork : NetworkBehaviour
{
    Snake snake;
    Transform tailTarget;

    [SyncVar]
    Snake owner;
    public Snake Owner
    {
        get { return owner; }
        private set { owner = value; }
    }
    [SyncVar]
    GameObject target;
    public GameObject Target
    {
        get { return target; }
        private set { target = value; }
    }

    public override void OnStartServer()
    {
        Owner = FindObjectOfType<Snake>();
        //connectionToClient.identity.GetComponent<Snake>();
        List<GameObject> tails = Owner.GetComponent<TailSpawner>().Tails;
        Target = tails.Count == 0 
            ? Owner.gameObject 
            : tails[tails.Count - 1];
        tails.Add(gameObject);
    }
}
