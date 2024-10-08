using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 10f;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private Text AIScore;
    [SerializeField] private Text PlayerScore;
    [SerializeField] private AudioSource bounceSound;  // Reference to the AudioSource component

    private int hitCounter;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2f);
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (speedIncrease * hitCounter));
    }

    private void StartBall()
    {
        rb.velocity = new Vector2(-1, 0) * (initialSpeed + speedIncrease * hitCounter);
    }

    private void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }

    private void PlayerBounce(Transform myObject)
    {
        hitCounter++;
        Debug.Log("Hit Counter: " + hitCounter);

        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;

        float xDirection = (transform.position.x > 0) ? -1 : 1;
        float yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;

        if (yDirection == 0)
        {
            yDirection = 0.25f;
        }

        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (speedIncrease * hitCounter));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            PlayerBounce(collision.transform);
        }
        else if (collision.gameObject.name == "Basic Background" ) // Checks if colliding with walls
        {
            if (bounceSound != null)
            {
                bounceSound.Play();  // Play the bounce sound effect
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            ResetBall();
            PlayerScore.text = (int.Parse(PlayerScore.text) + 1).ToString();
        }
        else if (transform.position.x < 0)
        {
            ResetBall();
            AIScore.text = (int.Parse(AIScore.text) + 1).ToString();
        }
    }
}
