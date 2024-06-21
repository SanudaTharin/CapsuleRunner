using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    PlayerMovements playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindAnyObjectByType<PlayerMovements>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player"){

            playerMovement.Die();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
