using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public float speed = 120;
    public float responseSpeed = 0f;
    public GameObject ball;
    public float minY = -3.45f;
    public float maxY = 3.45f;
    public float predictionTime = 1f;  
    public float errorFactor = 0.1f; 

    void FixedUpdate()
    {
        if (ball.GetComponent<Ball>().movement.x > 0)
        {
  
            Vector2 futureBallPosition = ball.transform.position + (Vector3)ball.GetComponent<Ball>().movement * predictionTime;

      
            float error = Random.Range(-errorFactor, errorFactor);
            float targetY = futureBallPosition.y + error;

          
            float newY = Mathf.Lerp(transform.position.y, targetY, responseSpeed * Time.deltaTime);

  
            newY = Mathf.Clamp(newY, minY, maxY);

            GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x, newY));
        }
    }
}
