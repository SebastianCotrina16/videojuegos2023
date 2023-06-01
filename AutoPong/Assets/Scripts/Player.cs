using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public float speed = 30f;
    public float minY = -10f;
    public float maxY = 10f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        Vector2 newPosition = rb.position + Vector2.up * vertical * speed * Time.fixedDeltaTime;

        // Aseg�rate de que la posici�n no exceda los l�mites.
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        rb.MovePosition(newPosition);
    }
}
