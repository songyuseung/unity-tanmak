using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    private Rigidbody Bulletrb;
    void Start()
    {
        Bulletrb = GetComponent<Rigidbody>();

        Bulletrb.velocity = transform.forward * Speed;

        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        
        if (playerController != null)
        {
            playerController.Die();
        }
    }
}
