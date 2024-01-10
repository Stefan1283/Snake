using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class TailSpawner : NetworkBehaviour
{
    public List<GameObject> Tails { get; } = new List<GameObject>();
    [SerializeField] GameObject tailPrefab;

    public override void OnStartServer()
    {
        Food.ServerOnFoodEaten += AddTail;
    }

    public override void OnStopServer()
    {
        Food.ServerOnFoodEaten -= AddTail;
    }

    void AddTail(GameObject playerWhoAte)
    {
        if (playerWhoAte != gameObject)
        {
            return;
        }

        Vector3 clonePosition = Tails.Count == 0 ?
            transform.position :
            Tails[Tails.Count - 1].transform.position;
        var tailInstance = Instantiate(tailPrefab, clonePosition, Quaternion.identity);
        NetworkServer.Spawn(tailInstance);
        Tails.Add(tailInstance);
    }
}
