using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private int score = 0;
    public int health = 5;
    void Start()
    {
        // No initialization needed for Start()
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        movement.Normalize(); // Normalize the movement vector to prevent faster diagonal movement

        transform.Translate(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }
    }

         void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
           
           score = 0;
           health = 5;
           Invoke("Restart", 2f);
           Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
