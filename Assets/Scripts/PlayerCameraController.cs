using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : NetworkBehaviour
{
    [SerializeField] GameObject camera;

    public override void OnStartAuthority()
    {
        camera.SetActive(true);
    }
}
