using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Networking;

public class ProjetilController : NetworkBehaviour {
    
    [SerializeField]private float moveSpeed = 20f;
    
    void Start()
    {
        Destroy(gameObject, 1);
    }

    void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * moveSpeed);
    }

    
    [ServerCallback]
    private void OnTriggerEnter(Collider other) {
        NetworkServer.Destroy(gameObject);
        NetworkServer.Destroy(other.gameObject);
    }
}
