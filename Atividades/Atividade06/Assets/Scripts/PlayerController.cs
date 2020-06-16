using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public PhotonView photonView;
    public float moveSpeed = 0.2f;
    public float moveRotation = 20f;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        if (!photonView.IsMine)
            return;
        transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed);
        transform.Rotate(0, Input.GetAxis("Horizontal") * moveRotation, 0);
    }
}
