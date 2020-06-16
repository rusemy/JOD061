using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class PlayerController : NetworkBehaviour {
    
    [SerializeField]private GameObject projetilPrefab;
    [SerializeField]private Transform projetilPosition;

    [SerializeField]private float moveSpeed = 0.1f;
    [SerializeField]private float moveRotation = 10f;
    
    private void Start()
    {
        Material material = GetComponent<Renderer>().material;
        material.color = new Color(Random.Range(0f, 255f), Random.Range(0f, 255f), Random.Range(0f, 255f));
    }

    private void Update()
    {
        if (!isLocalPlayer)
            return;

        transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed);
        transform.Rotate(0, Input.GetAxis("Horizontal") * moveRotation, 0);

        if (Input.GetKeyUp(KeyCode.Space))
            CmdAtirar();
    }

    private void CmdAtirar()
    {
        GameObject projetil = Instantiate(projetilPrefab, projetilPosition.position, transform.rotation);
        NetworkServer.Spawn(projetil);
    }
}
