using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public float acceleration = 0.2f;
    public Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        movement = new Vector2(1, 1).normalized;
        rb.velocity = movement * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        speed += acceleration;

        if (collision.gameObject.name == "PaddlePlayer" || collision.gameObject.name == "PaddleAI")
        {
            movement.x = -movement.x;
        }
        else
        {
            movement.y = -movement.y;
        }

        rb.velocity = movement * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Goal1")
        {
            ScoreManager.instance.AddPointPlayer1();
            ResetBall();
        }
        else if (other.gameObject.name == "Goal2")
        {
            ScoreManager.instance.AddPointPlayer2();
            ResetBall();
        }
    }

    void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        speed = 10f;
        LaunchBall();
    }
}
