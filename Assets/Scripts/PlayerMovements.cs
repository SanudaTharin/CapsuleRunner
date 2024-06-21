using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovements : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMultiplier = 2;
    bool alive = true;

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;

        Invoke("Restart", 2);

        
    }

    void Restart()
    {
        //restart the game when hit an obstacle
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
