using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeNetworkManager : NetworkManager
{
    [SerializeField] GameObject FoodSpawnerPrefab;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        if (numPlayers != 2)
        {
            return;
        }

        var FoodSpawnerInstance = Instantiate(FoodSpawnerPrefab);
        NetworkServer.Spawn(FoodSpawnerInstance);
    }

}
