using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float turnSpeed = 90f; //Turn the coin 90 degrees

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)  //Prevent coins colide with obstacles
        {
            Destroy(gameObject);
            return;
        }

        //Check the object we colided is player
        if (other.gameObject.name != "Player")
        {
            return;
        }

        //Counting the score of the player
        GameManager.inst.IncrementScore();

        //Destroy the coin
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);  //Coin will rotate every second regardless of the frame rate
    }
}
