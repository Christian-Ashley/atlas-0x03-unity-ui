using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image winLoseBG;
    public Text winloseText;
    public Text healthText;
    public float speed = 5f;
    private int score = 0;
    public int health = 5;
    public Text scoreText;
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
           /// Debug.Log("Score: " + score);
            other.gameObject.SetActive(false);
            SetScoreText();
        }
        if (other.CompareTag("Trap"))
        {
            health--;
            ///Debug.Log("Health: " + health);
            SetHealthText();
        }
        if (other.CompareTag("Goal"))
        {
            winLoseBG.gameObject.SetActive(true);
            winloseText.text = "You Win!";
            winloseText.color = Color.black;

            winLoseBG.color = Color.green;
            score = 0;
           health = 5;
           Invoke("Restart", 2f);
           Restart();
        }
    }

         void Update()
    {
        if (health == 0)
        {
           winLoseBG.gameObject.SetActive(true);
            winloseText.text = "Game Over!";
            winloseText.color = Color.white; 
           
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

    void SetScoreText()
    {
        scoreText.text = ("Score: " + score);
    }

    void SetHealthText()
    {
        healthText.text = ("Health: " + health);
    }
}
